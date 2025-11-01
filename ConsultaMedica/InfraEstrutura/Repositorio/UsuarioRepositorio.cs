using Dominio.Entidades;
using InfraEstrutura.Data;
using Interface.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private ConsultaContexto contexto;

        public UsuarioRepositorio(ConsultaContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Usuario> addAsync(Usuario usuario)
        {
            await this.contexto.Usuarios.AddAsync(usuario);
            await this.contexto.SaveChangesAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> getAllAsync(Expression<Func<Usuario, bool>> expression)
        {
            return await this.contexto.Usuarios.Where(expression).OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<Usuario?> getAsync(int id)
        {
            return await this.contexto.Usuarios.FindAsync(id);
        }

        public async Task removeAsync(Usuario usuario)
        {
            this.contexto.Usuarios.Remove(usuario);
            await this.contexto.SaveChangesAsync();

        }

        public async Task updateAsync(Usuario usuario)
        {
            this.contexto.Entry(usuario).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }
    }
}
