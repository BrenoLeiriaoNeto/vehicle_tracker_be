using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Exceptions.Profile;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetProfile;

public class GetProfileQueryHandler(
    IProfileQueryRepository queryRepository,
    IProfileMapper mapper
    ) : IRequestHandler<GetProfileQuery, ProfileViewModel>
{
    public async Task<ProfileViewModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var domain = await queryRepository.GetProfileAsync(request.UserId, cancellationToken);

        return domain is null 
            ? throw new ProfileNotFoundException("Perfil de usuário inexistente.") 
            : mapper.MapToViewModel(domain);
    }
}