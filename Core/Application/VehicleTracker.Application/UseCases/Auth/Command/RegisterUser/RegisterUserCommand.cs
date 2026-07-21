using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Auth.Command.RegisterUser;

public record RegisterUserCommand(CreateUserInputModel User) : IRequest<AuthViewModel>;