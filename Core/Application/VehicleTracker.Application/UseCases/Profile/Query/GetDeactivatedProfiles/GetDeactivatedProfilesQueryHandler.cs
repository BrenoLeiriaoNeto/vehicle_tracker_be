using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetDeactivatedProfiles;

public class GetDeactivatedProfilesQueryHandler(
    IProfileQueryRepository queryRepository,
    IProfileMapper mapper
    ) : IRequestHandler<GetDeactivatedProfilesQuery, IEnumerable<ProfileViewModel>>
{
    public async Task<IEnumerable<ProfileViewModel>> Handle(GetDeactivatedProfilesQuery request,
        CancellationToken cancellationToken)
    {
        var profiles = await queryRepository.GetDeactivatedProfilesAsync(cancellationToken);
        
        return mapper.MapToViewModels(profiles).ToList();
    }
}