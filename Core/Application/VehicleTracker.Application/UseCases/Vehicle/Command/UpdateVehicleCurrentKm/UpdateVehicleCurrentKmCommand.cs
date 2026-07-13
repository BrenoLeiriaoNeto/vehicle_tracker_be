using MediatR;
using VehicleTracker.Application.Contracts.Models.UpdateModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Command;

public record UpdateVehicleCurrentKmCommand(VehicleUpdateModel Update) : IRequest<Unit>;