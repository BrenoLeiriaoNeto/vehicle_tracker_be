namespace VehicleTracker.Application.Contracts.Models.ViewModels;

public record InvitationViewModel
(
    string Id,
    string InviteCode,
    string DriverEmail,
    DateTime ExpiresAt
    );