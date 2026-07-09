using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.UpdateModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Mappers;

public interface IVehicleMapper
{
    Vehicle MapToDomain(CreateVehicleInputModel input);
    Vehicle MapToDomain(VehicleUpdateModel update);
    VehicleViewModel MapToViewModel(Vehicle domain);
}