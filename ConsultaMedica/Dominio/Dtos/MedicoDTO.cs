using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.Dtos
{
    public class MedicoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public int IdConsulta { get; set; }
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public virtual List<Consulta> consultas { get; set; } = new List<Consulta>();
        [JsonIgnore]
        public virtual List<Usuario> usuario { get; set; } = new List<Usuario>();
    }
}
