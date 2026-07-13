using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Vehicle.Query;

namespace VehicleTracker.Application.UseCases.Vehicle.Handlers;

public class GetAllVehiclesQueryHandler(
    IVehicleQueryRepository queryRepository,
    IVehicleMapper mapper) : IRequestHandler<GetAllVehiclesQuery, IEnumerable<VehicleViewModel>>
{
    public async Task<IEnumerable<VehicleViewModel>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await queryRepository.GetAllVehiclesAsync(cancellationToken);

        var vehiclesList = mapper.MapToListViewModels(vehicles);

        return vehiclesList.ToList();
    }
}