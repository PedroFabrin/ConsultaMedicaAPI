using Dominio.Dtos;
using FluentValidation;
using Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultaController : ControllerBase
    {
        private IConsultaService service;
        private IValidator<ConsultaDTO> validator;

        public ConsultaController(IConsultaService service, IValidator<ConsultaDTO> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ConsultaDTO>> addAsync(ConsultaDTO consDto)
        {
            var result = validator.Validate(consDto);
            if (result.IsValid)
            {
                var dto = await this.service.addAsync(consDto);
                return Ok(dto);
            }
            else
                return BadRequest(result);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaDTO>>> getAllAsync()
        {
            var list = await this.service.getAllAsync(p => true);
            return Ok(list);
        }

        [HttpGet("filtrar/{dataConsulta}")]
        public async Task<ActionResult<IEnumerable<ConsultaDTO>>> getDataConsulta(DateTime dataConsulta)
        {
            var lista = await this.service.getAllAsync(p => p.dataConsulta == dataConsulta);
            return Ok(lista);
        }

        [HttpGet("retornarId/{id}")]
        public async Task<ActionResult<ConsultaDTO>> getAsync(int id)
        {
            var dto = await this.service.getAsync(id);
            if (dto == null)
                return NotFound();
            else
                return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAsync(int id)
        {
            await this.service.removeAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> updateAsync(ConsultaDTO dto)
        {
            await this.service.updateAsync(dto);
            return NoContent();
        }
    }
}
