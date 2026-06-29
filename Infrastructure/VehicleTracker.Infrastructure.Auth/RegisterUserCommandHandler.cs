using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.Handlers.Auth.Command;

namespace VehicleTracker.Infrastructure.Auth;

public class RegisterUserCommandHandler(
    IAuthCommandRepository commandRepository,
    IUserMapper mapper
    ) : IRequestHandler<RegisterUserCommand, AuthViewModel>
{
    public async Task<AuthViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userDomain = mapper.MapToDomain(request.User);

        await commandRepository.CreateUserAsync(userDomain, cancellationToken);

        return mapper.MapToViewModel(userDomain);
    }
}