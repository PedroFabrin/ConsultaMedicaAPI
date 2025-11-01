using Dominio.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaMedica.Validation
{
    public class MedicoValidation : AbstractValidator<MedicoDTO>
    {
        public MedicoValidation()
        {
            RuleFor(p => p.Nome).MaximumLength(200).WithMessage("O nome precisa ter no máximo 200 caractereres");
            RuleFor(p => p.Especialidade).NotEmpty().WithMessage("Informe a especialidade");
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Informe o Nome");
            RuleFor(p => p.Especialidade).MaximumLength(200).WithMessage("A especialidade deve conter no máximo 200caracteres");
        }
    }
}
