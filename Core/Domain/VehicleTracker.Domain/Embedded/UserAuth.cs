using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Domain.Embedded;

public class UserAuth
{
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiresAt { get; set; }
    public UserRole Role { get; private set; }
    public UserStatus Status { get; set; } = UserStatus.Active;

    public UserAuth()
    {
        
    }

    public UserAuth(string email, string passwordHash, UserRole role)
    {
        Email = email.ToLower().Trim();
        PasswordHash = passwordHash;
        Role = role;
    }
    
    public void UpdateRefreshToken(string refreshToken, DateTime refreshTokenExpiresAt)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiresAt = refreshTokenExpiresAt;
    }
    
    public void SetPassword(string passwordHash) => PasswordHash = passwordHash;
}