using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Query;

public record GetVehicleByIdQuery(string Id) : IRequest<VehicleViewModel>;