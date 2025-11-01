using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }

        public virtual List<Consulta> consultas { get; set; } = new List<Consulta>();
        public virtual List<Usuario> usuario { get; set; } = new List<Usuario>();

    }
}
