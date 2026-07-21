using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Exceptions.Profile;

namespace VehicleTracker.Application.UseCases.Profile.Command.UpdateProfile;

public class UpdateProfileCommandHandler(
    IProfileCommandRepository commandRepository,
    IProfileMapper mapper
    ) : IRequestHandler<UpdateProfileCommand, bool>
{
    public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = mapper.MapToDomain(request.Update);

        var result = await commandRepository.UpdateProfileAsync(profile, cancellationToken);

        return !result 
            ? throw new ProfileNotFoundException("Perfil de usuário inexistente.") 
            : result;
    }

}