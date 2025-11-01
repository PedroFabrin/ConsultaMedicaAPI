using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.Dtos
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int anoNascimento { get; set; }

        [JsonIgnore]
        public int IdMedico { get; set; }

        [JsonIgnore]
        public virtual List<Consulta> consultas { get; set; } = new List<Consulta>();
    }
}
