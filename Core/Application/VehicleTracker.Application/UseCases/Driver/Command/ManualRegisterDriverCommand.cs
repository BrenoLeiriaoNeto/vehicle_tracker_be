using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;

namespace VehicleTracker.Application.UseCases.Driver.Command;

public record ManualRegisterDriverCommand
(
    CreateUserInputModel User
    ) : IRequest<Unit>;