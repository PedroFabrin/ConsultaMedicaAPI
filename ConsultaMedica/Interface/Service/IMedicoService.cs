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
    public interface IMedicoService
    {
        Task<MedicoDTO> addAsync(MedicoDTO medicoDto);
        Task removeAsync(int id);
        Task<MedicoDTO?> getAsync(int id);
        Task<IEnumerable<MedicoDTO>> getAllAsync(Expression<Func<Medico, bool>> expression);
        Task updateAsync(MedicoDTO medicoDto);
    }
}
