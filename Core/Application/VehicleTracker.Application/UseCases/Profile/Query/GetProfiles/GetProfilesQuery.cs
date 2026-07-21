using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetProfiles;

public record GetProfilesQuery() : IRequest<IEnumerable<ProfileViewModel>>;