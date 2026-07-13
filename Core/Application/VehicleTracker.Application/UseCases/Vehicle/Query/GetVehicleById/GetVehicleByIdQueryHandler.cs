using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Exceptions.Vehicle;

namespace VehicleTracker.Application.UseCases.Vehicle.Query.GetVehicleById;

public class GetVehicleByIdQueryHandler(
    IVehicleQueryRepository queryRepository,
    IVehicleMapper mapper) : IRequestHandler<GetVehicleByIdQuery, VehicleViewModel>
{
    public async Task<VehicleViewModel> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await queryRepository.GetVehicleByIdAsync(request.Id, cancellationToken);

        return vehicle is null 
            ? throw new VehicleNotFoundException("Veículo não encontrado.") 
            : mapper.MapToViewModel(vehicle);
    }
}