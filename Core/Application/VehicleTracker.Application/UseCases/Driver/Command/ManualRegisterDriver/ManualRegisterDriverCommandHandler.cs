using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Exceptions;

namespace VehicleTracker.Application.UseCases.Driver.Command.ManualRegisterDriver;

public class ManualRegisterDriverCommandHandler(
    IAuthCommandRepository commandRepository,
    IUserMapper mapper,
    IPasswordHasher passwordHasher
    ) : IRequestHandler<ManualRegisterDriverCommand, Unit>
{
    public async Task<Unit> Handle(ManualRegisterDriverCommand request,
        CancellationToken cancellationToken)
    {
        
        if (string.IsNullOrEmpty(request.User.OwnerId))
            throw new BusinessRuleException("É preciso ter um gerente associado ao motorista");
        
        var passwordHash = passwordHasher.HashPassword(request.User.Password);

        var user = mapper.MapToDomain(request.User);
        
        user.SetOwner(request.User.OwnerId);
        user.Auth.SetPassword(passwordHash);
        user.Auth.SetPasswordToChange();

        await commandRepository.CreateUserAsync(user, cancellationToken);

        return Unit.Value;
    }
}