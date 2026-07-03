using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Query;

public interface IAuthQueryRepository
{
    Task<AuthViewModel> LoginAsync(User user);
    Task<bool> IsEmailUnique(string email, CancellationToken ct);
}