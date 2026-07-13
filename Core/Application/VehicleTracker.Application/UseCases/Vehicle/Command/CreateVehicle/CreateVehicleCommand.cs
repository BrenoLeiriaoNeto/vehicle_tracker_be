using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Command;

public record CreateVehicleCommand(CreateVehicleInputModel Input, string Name) : IRequest<Unit>;