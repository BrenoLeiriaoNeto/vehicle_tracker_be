using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;

namespace VehicleTracker.Application.UseCases.Driver.Command.ManualRegisterDriver;

public record ManualRegisterDriverCommand
(
    CreateUserInputModel User
    ) : IRequest<Unit>;