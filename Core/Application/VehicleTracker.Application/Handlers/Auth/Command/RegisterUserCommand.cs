using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.Handlers.Auth.Command;

public record RegisterUserCommand(CreateUserInputModel User) : IRequest<AuthViewModel>;