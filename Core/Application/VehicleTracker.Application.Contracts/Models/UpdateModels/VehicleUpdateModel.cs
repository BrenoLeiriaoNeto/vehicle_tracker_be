using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.Contracts.Models.UpdateModels;

public record VehicleUpdateModel(
    double? CurrentKm,
    VehicleStatus? Status
    );