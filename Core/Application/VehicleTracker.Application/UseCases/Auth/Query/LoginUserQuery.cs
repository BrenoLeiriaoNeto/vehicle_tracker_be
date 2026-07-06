using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Auth.Query;

public record LoginUserQuery
(LoginInputModel User) : IRequest<AuthViewModel>;