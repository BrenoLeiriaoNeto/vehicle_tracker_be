using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.UpdateModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Mappers;

public class VehicleMapper : IVehicleMapper
{
    public Vehicle MapToDomain(CreateVehicleInputModel input)
    {
        return new Vehicle(
            input.Plate,
            input.Brand,
            input.Model,
            input.Year,
            input.CurrentKm,
            input.Status,
            input.OwnerId
        );
    }

    public Vehicle MapToDomain(VehicleUpdateModel update)
    {
        return new Vehicle(
            update.Id,
            update.CurrentKm,
            update.Status
        );
    }

    public VehicleViewModel MapToViewModel(Vehicle domain)
    {
        return new VehicleViewModel(
            domain.Plate,
            domain.Brand,
            domain.Model,
            domain.Year,
            domain.CurrentKm,
            domain.Status
        );
    }

    public IEnumerable<VehicleViewModel> MapToListViewModels(IEnumerable<Vehicle> domain) =>
        domain.Select(MapToViewModel);
}