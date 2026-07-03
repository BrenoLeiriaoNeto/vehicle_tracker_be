using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Mappers;

public class InvitationMapper : IInvitationMapper
{
    public InvitationViewModel MapToViewModel(Invitation domain)
    {
        return new InvitationViewModel(
            Id: domain.Id,
            InviteCode: domain.InviteCode,
            DriverEmail: domain.DriverEmail,
            ExpiresAt: domain.ExpiresAt
        );
    }

    public Invitation MapToDomain(CreateInvitationInputModel input)
    {
        return new Invitation(input.OwnerId, input.DriverEmail);
    }
}