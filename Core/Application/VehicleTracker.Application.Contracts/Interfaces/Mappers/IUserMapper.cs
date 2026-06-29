using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Mappers;

public interface IUserMapper
{
    AuthViewModel MapToViewModel(User domain);
    User MapToDomain(CreateUserInputModel input);
}