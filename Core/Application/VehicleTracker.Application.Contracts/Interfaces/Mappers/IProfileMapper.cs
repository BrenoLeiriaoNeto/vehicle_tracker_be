using VehicleTracker.Application.Contracts.Models.UpdateModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Mappers;

public interface IProfileMapper
{
    User MapToDomain(ProfileUpdateModel update);
    ProfileViewModel MapToViewModel(User domain);
    IEnumerable<ProfileViewModel> MapToViewModels(IEnumerable<User> domains);
}