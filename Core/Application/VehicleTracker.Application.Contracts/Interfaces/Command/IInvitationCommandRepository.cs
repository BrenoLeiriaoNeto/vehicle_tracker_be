using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Command;

public interface IInvitationCommandRepository
{
    Task CreateInvitationAsync(Invitation invitation, CancellationToken ct);
    Task UpdateInvitationAsync(Invitation invitation, CancellationToken ct);
}