using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetDeactivatedProfiles;

public record GetDeactivatedProfilesQuery() : IRequest<IEnumerable<ProfileViewModel>>;