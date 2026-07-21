using MediatR;
using VehicleTracker.Application.Contracts.Models.UpdateModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.UpdateVehicleCurrentKm;

public record UpdateVehicleCurrentKmCommand(VehicleUpdateModel Update) : IRequest<Unit>;