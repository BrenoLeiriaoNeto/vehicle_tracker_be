using MediatR;

namespace VehicleTracker.Application.UseCases.Profile.Command.UpdateProfileMetrics;

public record UpdateProfileMetricsCommand(string UserId, double SumKilometers) : IRequest<Unit>;