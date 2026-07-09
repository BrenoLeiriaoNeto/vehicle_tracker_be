using MediatR;
using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Invitations.Command;
using VehicleTracker.Exceptions;

namespace VehicleTracker.Application.UseCases.Invitations.Handlers;

public class RegisterDriverByInviteCommandHandler(
    IInvitationCommandRepository commandRepository,
    IInvitationQueryRepository queryRepository,
    IAuthCommandRepository authCommandRepository,
    IUserMapper userMapper,
    IMongoClient mongoClient,
    IJwtProvider jwtProvider,
    IPasswordHasher passwordHasher
    ) : IRequestHandler<RegisterDriverByInviteCommand, AuthViewModel>
{
    public async Task<AuthViewModel> Handle(RegisterDriverByInviteCommand request,
        CancellationToken cancellationToken)
    {
        var invitation =
            await queryRepository.GetByCodeAsync(request.Driver.InviteCode, cancellationToken);

        if (invitation is null)
            throw new InvitationNotFoundException("Convite não encontrado ou inválido.");

        if (!invitation.CanBeAccepted(request.Driver.Email))
            throw new InvitationExpiredException(
                "Este convite expirou, já foi utilizado ou não foi emitido para este e-mail.");

        var newDriver = userMapper.MapToDomain(request.Driver);
        
        var accessToken = jwtProvider.GenerateToken(newDriver);
        var refreshToken = jwtProvider.GenerateRefreshToken();
        var expiresAt = DateTime.UtcNow.AddMinutes(15);

        newDriver.Auth.SetPassword(passwordHasher.HashPassword(newDriver.Auth.PasswordHash));
        
        newDriver.SetOwner(invitation.OwnerId);
        
        invitation.MarkAsUsed();

        using var session =
            await mongoClient.StartSessionAsync(cancellationToken: cancellationToken);

        try
        {
            session.StartTransaction();
            
            await commandRepository.UpdateInvitationAsync(session, invitation, cancellationToken);
            await authCommandRepository.CreateUserAsync(session, newDriver, cancellationToken);

            await session.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception e)
        {
            await session.AbortTransactionAsync(cancellationToken);
            throw;
        }
        
        return userMapper.MapToViewModel(newDriver, accessToken, refreshToken, expiresAt);
    }
}