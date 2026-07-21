using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Models.UpdateModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Mappers;

public class ProfileMapper : IProfileMapper
{
    public User MapToDomain(ProfileUpdateModel update)
    {
        return new User(
            update.Name,
            update.Bio
            );
    }

    public ProfileViewModel MapToViewModel(User domain)
    {
        return new ProfileViewModel(
            domain.Name,
            domain.Bio,
            domain.Metrics
        );
    }

    public IEnumerable<ProfileViewModel> MapToViewModels(IEnumerable<User> domains) =>
         domains.Select(MapToViewModel);
}