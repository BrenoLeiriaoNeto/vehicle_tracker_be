using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetProfiles;

public class GetProfilesQueryHandler(
    IProfileQueryRepository queryRepository,
    IProfileMapper mapper
    ) : IRequestHandler<GetProfilesQuery, IEnumerable<ProfileViewModel>>
{
    public async Task<IEnumerable<ProfileViewModel>> Handle(GetProfilesQuery request,
        CancellationToken cancellationToken)
    {
        var profiles = await queryRepository.GetProfilesAsync(cancellationToken);

        return mapper.MapToViewModels(profiles).ToList();
    }
}