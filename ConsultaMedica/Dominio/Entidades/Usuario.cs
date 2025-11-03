using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int anoNascimento { get; set; }

        // 👇 FK opcional (pode ser null)
        public int? IdMedico { get; set; }

        // 👇 Propriedade de navegação (pra acessar o médico)
        public virtual Medico? Medico { get; set; }

        public virtual List<Consulta> consultas { get; set; } = new List<Consulta>();
    }

}
