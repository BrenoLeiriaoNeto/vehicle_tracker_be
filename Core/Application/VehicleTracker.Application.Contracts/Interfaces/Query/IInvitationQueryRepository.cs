using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Query;

public interface IInvitationQueryRepository
{
    Task<Invitation?> GetByCodeAsync(string inviteCode, CancellationToken ct);
}