using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Interface.Repositorio
{
    public interface IConsultaRepositorio
    {
        Task<Consulta> addAsync(Consulta consulta);
        Task removeAsync(Consulta consulta);
        Task<Consulta?> getAsync(int id);
        Task<IEnumerable<Consulta>> getAllAsync(Expression<Func<Consulta, bool>> expression);
        Task updateAsync(Consulta consulta);
    }
}
