using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Query;

public record GetAllVehiclesQuery() : IRequest<IEnumerable<VehicleViewModel>>;
