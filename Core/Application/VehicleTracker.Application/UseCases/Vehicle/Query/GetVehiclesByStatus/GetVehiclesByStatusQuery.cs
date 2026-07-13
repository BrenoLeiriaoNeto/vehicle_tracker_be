using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.UseCases.Vehicle.Query;

public record GetVehiclesByStatusQuery(VehicleStatus Status) 
    : IRequest<IEnumerable<VehicleViewModel>>;