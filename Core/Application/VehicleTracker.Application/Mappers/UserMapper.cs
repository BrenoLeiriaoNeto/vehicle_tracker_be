using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Mappers;

public class UserMapper(
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider
    ) : IUserMapper
{
    public AuthViewModel MapToViewModel(User domain)
    {
        var accessToken = jwtProvider.GenerateToken(domain);
        var refreshToken = jwtProvider.GenerateRefreshToken();
        var expiresAt = DateTime.UtcNow.AddMinutes(15);
        
        var sessionInfo = new UserSessionInfo(
            domain.Id,
            domain.Name,
            domain.Email,
            domain.Role.ToString(),
            domain.OwnerId,
            domain.AvatarUrl
        );
        
        return new AuthViewModel(accessToken, refreshToken, expiresAt, sessionInfo);
    }

    public User MapToDomain(CreateUserInputModel input)
    {
        var passwordHash = passwordHasher.HashPassword(input.Password);

        return new User(
            email: input.Email,
            passwordHash: passwordHash,
            name: input.Name
        );
    }

    public User MapToDomain(CreateDriverByInviteInputModel input)
    {
        var passwordHash = passwordHasher.HashPassword(input.Password);
        
        return new User(
            email: input.Email,
            passwordHash: passwordHash,
            name: input.Name
        );
    }
}