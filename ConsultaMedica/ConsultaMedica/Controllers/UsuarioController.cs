using Dominio.Dtos;
using InfraEstrutura.Repositorio;
using Interface.Service;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ConsultaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService service;
        private IValidator<UsuarioDTO> validator;

        public UsuarioController(IUsuarioService service, IValidator<UsuarioDTO> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UsuarioDTO>> addAsync(UsuarioDTO usuDto)
        {
            var result = validator.Validate(usuDto);
            if (result.IsValid)
            {
                var dto = await this.service.addAsync(usuDto);
                return Ok(dto);
            }
            else
                return BadRequest(result);
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> getAllAsync()
        {
            var list = await this.service.getAllAsync(p => true);
            return Ok(list);
        }

        [HttpGet("filtrar/{nome}")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> getNomeAsync(string nome)
        {
            var lista = await this.service.getAllAsync(p => p.Nome.Contains(nome));
            return Ok(lista);
        }

        [HttpGet("retornarId/{id}")]
        public async Task<ActionResult<UsuarioDTO>> getAsync(int id)
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
        public async Task<ActionResult> updateAsync(UsuarioDTO dto)
        {
            await this.service.updateAsync(dto);
            return NoContent();
        }
    }
}
