using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Vehicle.Query;

namespace VehicleTracker.Application.UseCases.Vehicle.Handlers;

public class GetVehiclesByStatusQueryHandler(
    IVehicleQueryRepository queryRepository,
    IVehicleMapper mapper)
    : IRequestHandler<GetVehiclesByStatusQuery, IEnumerable<VehicleViewModel>>
{
    public async Task<IEnumerable<VehicleViewModel>> Handle(GetVehiclesByStatusQuery request, CancellationToken cancellationToken)
    {
        var vehicles =
            await queryRepository.GetVehiclesByStatusAsync(request.Status, cancellationToken);

        return mapper.MapToListViewModels(vehicles).ToList();
    }
}