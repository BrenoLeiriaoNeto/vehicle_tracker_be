using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Exceptions.Profile;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetProfileByEmail;

public class GetProfileByEmailQueryHandler(
    IProfileQueryRepository queryRepository,
    IProfileMapper mapper
    ) : IRequestHandler<GetProfileByEmailQuery, ProfileViewModel>
{
    public async Task<ProfileViewModel> Handle(GetProfileByEmailQuery request, CancellationToken cancellationToken)
    {
        var profile =
            await queryRepository.GetProfileByEmailAsync(request.Email, cancellationToken);
        
        return profile is null 
            ? throw new ProfileNotFoundException("Perfil de usuário inexistente.")
            : mapper.MapToViewModel(profile);
    }
}