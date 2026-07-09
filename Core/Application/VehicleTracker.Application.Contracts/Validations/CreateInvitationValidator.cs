using FluentValidation;
using VehicleTracker.Application.Contracts.Models.InputModels;

namespace VehicleTracker.Application.Contracts.Validations;

public class CreateInvitationValidator : AbstractValidator<CreateInvitationInputModel>
{
    public CreateInvitationValidator()
    {
        RuleFor(x => x.DriverEmail)
            .NotEmpty().WithMessage("E-mail é obrigatório.")
            .EmailAddress().WithMessage("Formato de e-mail inválido.");

        RuleFor(x => x.OwnerId)
            .NotEmpty().WithMessage("O ID do owner é obrigatório.");
    }
}