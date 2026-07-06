using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Auth.Query;
using VehicleTracker.Exceptions;

namespace VehicleTracker.Application.UseCases.Auth.Handlers;

public class LoginUserQueryHandler(
    IAuthQueryRepository queryRepository,
    IAuthCommandRepository commandRepository,
    IUserMapper mapper,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider) : IRequestHandler<LoginUserQuery, AuthViewModel>
{
    public async Task<AuthViewModel> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await queryRepository.GetUserByEmailAsync(request.User.Email, cancellationToken);

        if (user is null || !passwordHasher.VerifyPassword(request.User.Password, user.Auth.PasswordHash))
            throw new EmailOrPasswordException("Usuário não encontrado.");

        var accessToken = jwtProvider.GenerateToken(user);
        var refreshToken = jwtProvider.GenerateRefreshToken();
        var expiresAt = DateTime.UtcNow.AddMinutes(15);
        
        user.Auth.UpdateRefreshToken(refreshToken, expiresAt);
        
        await commandRepository.UpdateUserAsync(user.Id, refreshToken, cancellationToken);
        
        return mapper.MapToViewModel(user, accessToken, refreshToken, expiresAt);
    }
}