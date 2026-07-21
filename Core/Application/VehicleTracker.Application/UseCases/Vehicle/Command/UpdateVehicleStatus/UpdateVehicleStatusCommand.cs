using MediatR;
using VehicleTracker.Application.Contracts.Models.UpdateModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.UpdateVehicleStatus;

public record UpdateVehicleStatusCommand(VehicleUpdateModel Update) : IRequest<Unit>;