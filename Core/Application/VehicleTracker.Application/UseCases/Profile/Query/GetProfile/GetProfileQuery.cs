using MediatR;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Profile.Query.GetProfile;

public record GetProfileQuery(string UserId) : IRequest<ProfileViewModel>;