using VehicleTracker.Domain.Embedded;

namespace VehicleTracker.Application.Contracts.Models.ViewModels;

public record ProfileViewModel(
    string Name,
    string? Bio,
    ProfileMetrics? Metrics
    );