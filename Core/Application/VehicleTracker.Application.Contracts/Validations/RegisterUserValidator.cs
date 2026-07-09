using FluentValidation;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.InputModels;

namespace VehicleTracker.Application.Contracts.Validations;

public class RegisterUserValidator : AbstractValidator<CreateUserInputModel>
{
    public RegisterUserValidator(IAuthQueryRepository queryRepository)
    {
        var queryRepository1 = queryRepository;
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Formato de e-mail inválido")
            .MustAsync(async (email, ct) => await queryRepository1.IsEmailUnique(email, ct))
            .WithMessage("Este e-mail já está cadastrado no sistema.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.")
            .MaximumLength(20).WithMessage("A senha deve ter no máximo 20 caracteres.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório")
            .MaximumLength(100).WithMessage("O nome não pode passar de 100 caracteres");
        
    }
    
    
}