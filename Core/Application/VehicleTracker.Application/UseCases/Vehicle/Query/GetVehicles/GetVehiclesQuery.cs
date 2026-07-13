using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.UseCases.Vehicle.Query.GetVehicles;

public record GetVehiclesQuery(VehicleStatus? Status, string? UserId) : IRequest<IEnumerable<VehicleViewModel>>;