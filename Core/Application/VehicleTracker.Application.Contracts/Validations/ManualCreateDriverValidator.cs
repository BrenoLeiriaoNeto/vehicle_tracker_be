using FluentValidation;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.InputModels;

namespace VehicleTracker.Application.Contracts.Validations;

public class ManualCreateDriverValidator : AbstractValidator<CreateUserInputModel>
{
    public ManualCreateDriverValidator(IAuthQueryRepository queryRepository)
    {

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100).WithMessage("Nome não pode ter mais de 100 caracteres.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório")
            .EmailAddress().WithMessage("Formato de e-mail inválido")
            .MustAsync(async (email, ct) => await queryRepository.IsEmailUnique(email, ct))
            .WithMessage("Este e-mail já está cadastrado no sistema.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.")
            .MaximumLength(20).WithMessage("A senha deve ter no máximo 20 caracteres.");
    }
}