using Dominio.Dtos;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> addAsync(UsuarioDTO usuarioDto);
        Task removeAsync(int id);
        Task<UsuarioDTO?> getAsync(int id);
        Task<IEnumerable<UsuarioDTO>> getAllAsync(Expression<Func<Usuario, bool>> expression);
        Task updateAsync(UsuarioDTO usuarioDto);
        
    }
}
