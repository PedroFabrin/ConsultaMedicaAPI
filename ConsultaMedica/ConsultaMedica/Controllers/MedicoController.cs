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
    public class MedicoController : ControllerBase
    {
        private IMedicoService service;
        private IValidator<MedicoDTO> validator;

        public MedicoController(IMedicoService service, IValidator<MedicoDTO> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MedicoDTO>> addAsync(MedicoDTO medDto)
        {
            var result = validator.Validate(medDto);
            if (result.IsValid)
            {
                var dto = await this.service.addAsync(medDto);
                return Ok(dto);
            }
            else
                return BadRequest(result);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> getAllAsync()
        {
            var list = await this.service.getAllAsync(p => true);
            return Ok(list);
        }

        [HttpGet("filtrar/{Especialidade}")]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> getEspecialidadeAsync(string Especialidade)
        {
            var lista = await this.service.getAllAsync(p => p.Especialidade.Contains(Especialidade));
            return Ok(lista);
        }

        [HttpGet("retornarId/{id}")]
        public async Task<ActionResult<MedicoDTO>> getAsync(int id)
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
        public async Task<ActionResult> updateAsync(MedicoDTO dto)
        {
            await this.service.updateAsync(dto);
            return NoContent();
        }
    }
}
