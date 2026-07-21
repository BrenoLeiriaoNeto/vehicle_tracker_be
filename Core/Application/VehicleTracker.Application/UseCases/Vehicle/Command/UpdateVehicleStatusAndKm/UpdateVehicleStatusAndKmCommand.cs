using MediatR;
using VehicleTracker.Application.Contracts.Models.UpdateModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.UpdateVehicleStatusAndKm;

public record UpdateVehicleStatusAndKmCommand(VehicleUpdateModel Update) : IRequest<Unit>;