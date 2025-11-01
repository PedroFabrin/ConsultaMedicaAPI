using Dominio.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaMedica.Validation
{
    public class ConsultaValidation : AbstractValidator<ConsultaDTO>
    {
        public ConsultaValidation()
        {
            RuleFor(p => p.dataConsulta).NotEmpty().WithMessage("Informe a data que a consulta será realizada");
        }
    }
}
