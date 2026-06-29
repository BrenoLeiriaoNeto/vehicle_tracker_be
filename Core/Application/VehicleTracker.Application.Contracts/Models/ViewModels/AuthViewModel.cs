namespace VehicleTracker.Application.Contracts.Models.ViewModels;

public record AuthViewModel
(
    string AccessToken,
    string RefreshToken,
    DateTime ExpiresAt,
    UserSessionInfo User
    );
    
    public record UserSessionInfo(
        string Id,
        string Name,
        string Email,
        string Role,
        string? OwnerId,
        string? AvatarUrl
        );