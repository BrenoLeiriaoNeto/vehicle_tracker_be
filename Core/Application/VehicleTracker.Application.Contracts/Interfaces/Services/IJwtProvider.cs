using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Services;

public interface IJwtProvider
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
}