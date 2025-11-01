using Dominio.Entidades;
using Dominio.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Interface.Service
{
    public interface IConsultaService
    {
        Task<ConsultaDTO> addAsync(ConsultaDTO consultaDto);
        Task removeAsync(int id);
        Task<ConsultaDTO?> getAsync(int id);
        Task<IEnumerable<ConsultaDTO>> getAllAsync(Expression<Func<Consulta, bool>> expression);
        Task updateAsync(ConsultaDTO consultaDto);
    }
}
