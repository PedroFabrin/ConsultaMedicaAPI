using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositorio
{
    public interface ISecretariaRepositorio
    {
        Task<Secretaria> addAsync(Secretaria secretaria);
        Task removeAsync(Secretaria secretaria);
        Task<Secretaria?> getAsync(int id);
        Task<IEnumerable<Secretaria>> getAllAsync(Expression<Func<Secretaria, bool>> expression);
        Task updateAsync(Secretaria secretaria);
        Task<Secretaria?> getSecretaria(Expression<Func<Secretaria, bool>> expression);
    }
}
