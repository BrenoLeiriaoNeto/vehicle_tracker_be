using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Vehicle.Query.GetVehicles;

public class GetVehiclesQueryHandler(
    IVehicleQueryRepository queryRepository,
    IVehicleMapper mapper
    ) : IRequestHandler<GetVehiclesQuery, IEnumerable<VehicleViewModel>>
{
    public async Task<IEnumerable<VehicleViewModel>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles =
            await queryRepository.GetVehicles(request.Status, request.UserId, cancellationToken);
        
        return mapper.MapToListViewModels(vehicles);
    }
}