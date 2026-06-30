using FluentValidation;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.Application.Contracts.Validations;

public class RegisterUserValidator : AbstractValidator<CreateUserInputModel>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Formato de e-mail inválido");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.")
            .MaximumLength(20).WithMessage("A senha deve ter no máximo 20 caracteres.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório")
            .MaximumLength(100).WithMessage("O nome não pode passar de 100 caracteres");
        
    }
}