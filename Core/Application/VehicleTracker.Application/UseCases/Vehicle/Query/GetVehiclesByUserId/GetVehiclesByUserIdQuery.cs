using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Query;

public record GetVehiclesByUserIdQuery(string UserId) : IRequest<IEnumerable<VehicleViewModel>>;