using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Domain.Models;
using VehicleTracker.Infrastructure.Services.Settings;

namespace VehicleTracker.Infrastructure.Services;

public class JwtProvider(JwtSettings settings) : IJwtProvider
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(settings.Secret);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Name, user.Name),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        if (!string.IsNullOrEmpty(user.OwnerId))
        {
            claims.Add(new Claim("ownerId", user.OwnerId));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(settings.AccessTokenExpirationInMinutes),
            Issuer = settings.Issuer,
            Audience = settings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}