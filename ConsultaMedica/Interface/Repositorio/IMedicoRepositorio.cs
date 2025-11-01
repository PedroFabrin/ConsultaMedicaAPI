using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositorio
{
    public interface IMedicoRepositorio
    {
        Task<Medico> addAsync(Medico medico);
        Task removeAsync(Medico medico);
        Task<Medico?> getAsync(int id);
        Task<IEnumerable<Medico>> getAllAsync(Expression<Func<Medico, bool>> expression);
        Task updateAsync(Medico medico);
    }
}
