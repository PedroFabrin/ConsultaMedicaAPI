using Dominio.Dtos;
using FluentValidation;

namespace ConsultaMedica.Validation
{
    public class SecretariaValidator : AbstractValidator<SecretariaDTO>
    {
        public SecretariaValidator()
        {
            RuleFor(p => p.Nome).MaximumLength(200).WithMessage("O nome precisa ter no máximo 200 caractreres");
            RuleFor(p => p.email).NotEmpty().WithMessage("Informe o email");
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Informe o Nome");
            RuleFor(p => p.senha).NotEmpty().WithMessage("Informe a senha");
            RuleFor(p => p.senha).MaximumLength(20).WithMessage("a senha precisa ter no máximo 20 caractreres");
        }
    }
}
