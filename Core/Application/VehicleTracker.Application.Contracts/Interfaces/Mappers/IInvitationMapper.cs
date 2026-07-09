using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Mappers;

public interface IInvitationMapper
{
    InvitationViewModel MapToViewModel(Invitation domain);
    Invitation MapToDomain(CreateInvitationInputModel input);
}