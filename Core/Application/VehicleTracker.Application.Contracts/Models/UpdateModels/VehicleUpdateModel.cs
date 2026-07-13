using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.Contracts.Models.UpdateModels;

public record VehicleUpdateModel(
    string Id,
    double? CurrentKm,
    VehicleStatus? Status
    );