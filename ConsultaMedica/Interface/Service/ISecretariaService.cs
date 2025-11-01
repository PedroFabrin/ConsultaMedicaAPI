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
    public interface ISecretariaService
    {
        Task<SecretariaDTO> addAsync(SecretariaDTO secretariaDTO);
        Task removeAsync(int id);
        Task<SecretariaDTO?> getAsync(int id);
        Task<IEnumerable<SecretariaDTO>> getAllAsync(Expression<Func<Secretaria, bool>> expression);
        Task updateAsync(SecretariaDTO secretariaDTO);
        Task<SecretariaDTO?> getSecretaria(string email, string senha);
    }
}
