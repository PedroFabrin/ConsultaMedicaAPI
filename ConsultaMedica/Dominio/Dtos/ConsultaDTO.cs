using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dtos
{
    public class ConsultaDTO
    {
        public int Id { get; set; }
        public DateTime dataConsulta { get; set; }
        public int IdMedico { get; set; }
        public int IdUsuario { get; set; }
    }
}
