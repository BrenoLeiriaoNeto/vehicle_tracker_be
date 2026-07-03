using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Command;

public class InvitationCommandRepository(IMongoDatabase database) : IInvitationCommandRepository
{
    private readonly IMongoCollection<Invitation> _invitationsCollection =
        database.GetCollection<Invitation>("Invitations");
    
    public async Task CreateInvitationAsync(Invitation invitation, CancellationToken ct)
    {
        await _invitationsCollection.InsertOneAsync(invitation, null, ct);
    }

    public async Task UpdateInvitationAsync(Invitation invitation, CancellationToken ct)
    {
        await _invitationsCollection.ReplaceOneAsync(x => x.Id == invitation.Id, invitation,
            cancellationToken: ct);
    }
}