using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Query;

public class InvitationQueryRepository(IMongoDatabase database) : IInvitationQueryRepository
{
    private readonly IMongoCollection<Invitation> _invitationsCollection =
        database.GetCollection<Invitation>("Invitations");
    
    public async Task<Invitation?> GetByCodeAsync(string inviteCode, CancellationToken ct)
    {
        return await _invitationsCollection
            .Find(x => x.InviteCode == inviteCode.ToUpper().Trim())
            .FirstOrDefaultAsync(ct);
    }
}