using Dominio.Dtos;
using FluentValidation;

namespace ConsultaMedica.Validation
{
    public class UsuarioValidation : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidation() {
            RuleFor(p => p.Nome).MaximumLength(200).WithMessage("O nome precisa ter no máximo 200 caractreres");
            RuleFor(p => p.anoNascimento).NotEmpty().WithMessage("Informe o ano de nascimento");
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Informe o Nome");
        }
    }
}
