using Dominio.Dtos;
using FluentValidation;
using Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConsultaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SecretariaController : ControllerBase
    {
        private ISecretariaService service;
        private IValidator<SecretariaDTO> validator;
        private IConfiguration _config;

        public SecretariaController(ISecretariaService service, IValidator<SecretariaDTO> validator, IConfiguration Configuration)
        {
            this.service = service;
            this.validator = validator;
            _config = Configuration;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<SecretariaDTO>> addAsync(SecretariaDTO secDto)
        {
            var result = validator.Validate(secDto);
            if (result.IsValid)
            {
                var dto = await this.service.addAsync(secDto);
                return Ok(dto);
            }
            else
                return BadRequest(result);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecretariaDTO>>> getAllAsync()
        {
            var list = await this.service.getAllAsync(p => true);
            return Ok(list);
        }

        [HttpGet("filtrar/{nome}")]
        public async Task<ActionResult<IEnumerable<SecretariaDTO>>> getNomeAsync(string nome)
        {
            var lista = await this.service.getAllAsync(p => p.Nome.Contains(nome));
            return Ok(lista);
        }

        [HttpGet("retornarId/{id}")]
        public async Task<ActionResult<SecretariaDTO>> getAsync(int id)
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
        public async Task<ActionResult> updateAsync(SecretariaDTO dto)
        {
            await this.service.updateAsync(dto);
            return NoContent();
        }

        [HttpPost("verificarSecretaria")]
        public async Task<ActionResult<SecretariaDTO>> GetSecretariaAsync(SecretariaDTO dTO)
        {
            var secretaria = await this.service.getSecretaria(dTO.email, dTO.senha);
            if(secretaria is null)
            {
                return NotFound();
            }
            else
            {
                var tokenString = GerarTokenJWT();
                return Ok(new
                {
                    access_token = tokenString,
                    token_type = "Bearer",
                    expires_in = 60 * 60 // 60 min
                });
            }
        }


        private string GerarTokenJWT()
        {

            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
