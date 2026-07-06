using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Auth.Command;

namespace VehicleTracker.Application.UseCases.Auth.Handlers;

public class RegisterUserCommandHandler(
    IAuthCommandRepository commandRepository,
    IUserMapper mapper,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider
    ) : IRequestHandler<RegisterUserCommand, AuthViewModel>
{
    public async Task<AuthViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        
        var userDomain = mapper.MapToDomain(request.User);
        
        userDomain.Auth.SetPassword(passwordHasher.HashPassword(request.User.Password));
        
        var accessToken = jwtProvider.GenerateToken(userDomain);
        var refreshToken = jwtProvider.GenerateRefreshToken();
        var expiresAt = DateTime.UtcNow.AddMinutes(15);

        await commandRepository.CreateUserAsync(userDomain, cancellationToken);

        return mapper.MapToViewModel(userDomain, accessToken, refreshToken, expiresAt);
    }
}