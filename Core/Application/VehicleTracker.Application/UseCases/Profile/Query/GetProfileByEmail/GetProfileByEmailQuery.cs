using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetProfileByEmail;

public record GetProfileByEmailQuery(string Email) : IRequest<ProfileViewModel>;