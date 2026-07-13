using FluentValidation;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.InputModels;

namespace VehicleTracker.Application.Contracts.Validations;

public class CreateVehicleValidator : AbstractValidator<CreateVehicleInputModel>
{
    public CreateVehicleValidator(
        IVehicleQueryRepository queryRepository,
        IAuthQueryRepository authQueryRepository)
    {
        RuleFor(x => x.Plate)
            .NotEmpty().WithMessage("Placa do carro é obrigatória.")
            .MustAsync(async (plate, ct) => await queryRepository.IsPlateUnique(plate, ct))
            .WithMessage("Esta placa ja esta cadastrada no sistema.");

        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Fabricante é obrigatória.");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Modelo é obrigatório.");

        RuleFor(x => x.Year)
            .NotEmpty().WithMessage("Ano é obrigatório.");

        RuleFor(x => x.CurrentKm)
            .GreaterThanOrEqualTo(0).WithMessage("Kilometragem atual é obrigatória.");

        RuleFor(x => x.OwnerId)
            .NotEmpty().WithMessage("ID do gerente é obrigatória.")
            .MustAsync(async (ownerId, ct) => await authQueryRepository.IsUserOwnerAsync(ownerId, ct))
            .WithMessage("O usuário precisa ser o dono da frota.");
    }
}