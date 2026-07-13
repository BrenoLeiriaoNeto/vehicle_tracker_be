using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Vehicle.Query;

namespace VehicleTracker.Application.UseCases.Vehicle.Handlers;

public class GetVehiclesByUserIdQueryHandler (
    IVehicleQueryRepository queryRepository,
    IVehicleMapper mapper)
    : IRequestHandler<GetVehiclesByUserIdQuery, IEnumerable<VehicleViewModel>>
{
    public async Task<IEnumerable<VehicleViewModel>> Handle(GetVehiclesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var vehicles =
            await queryRepository.GetVehiclesByUserIdAsync(request.UserId, cancellationToken);
        
        return mapper.MapToListViewModels(vehicles).ToList();
    }
}