using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Consulta
    {
        public int Id {  get; set; }
        public DateTime dataConsulta { get; set; }
        public int IdUsuario { get; set; }
        public int IdMedico { get; set; }

        
        public virtual Usuario? usuario { get; set; }
        public virtual Medico? medico { get; set; }
    }
}
