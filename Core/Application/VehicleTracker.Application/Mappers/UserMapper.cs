using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Mappers;

public class UserMapper(
    IPasswordHasher passwordHasher
    ) : IUserMapper
{
    public AuthViewModel MapToViewModel(User domain, string accessToken, string refreshToken,
        DateTime expiresAt)
    {
        
        var sessionInfo = new UserSessionInfo(
            domain.Id,
            domain.Name,
            domain.Auth.Email,
            domain.Auth.Role.ToString(),
            domain.OwnerId,
            domain.AvatarUrl
        );
        
        return new AuthViewModel(accessToken, refreshToken, expiresAt, sessionInfo);
    }

    public User MapToDomain(CreateUserInputModel input)
    {

        return new User(
            email: input.Email,
            passwordHash: input.Password,
            name: input.Name
        );
    }

    public User MapToDomain(CreateDriverByInviteInputModel input)
    {
        
        return new User(
            email: input.Email,
            passwordHash: input.Password,
            name: input.Name
        );
    }
}