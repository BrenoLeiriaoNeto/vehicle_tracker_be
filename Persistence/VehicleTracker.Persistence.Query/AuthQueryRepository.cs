using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Query;

public class AuthQueryRepository : IAuthQueryRepository
{
    public Task<AuthViewModel> LoginAsync(User user)
    {
        throw new NotImplementedException();
    }
}