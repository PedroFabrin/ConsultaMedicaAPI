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
    public class SecretariaRepositorio : ISecretariaRepositorio
    {
        private ConsultaContexto contexto;

        public SecretariaRepositorio(ConsultaContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Secretaria> addAsync(Secretaria secretaria)
        {
            await this.contexto.Secretarias.AddAsync(secretaria);
            await this.contexto.SaveChangesAsync();
            return secretaria;
        }

        public async Task<IEnumerable<Secretaria>> getAllAsync(Expression<Func<Secretaria, bool>> expression)
        {
            return await this.contexto.Secretarias.Where(expression).OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<Secretaria?> getAsync(int id)
        {
            return await this.contexto.Secretarias.FindAsync(id);
        }

        public async Task removeAsync(Secretaria secretaria)
        {
            this.contexto.Secretarias.Remove(secretaria);
            await this.contexto.SaveChangesAsync();

        }

        public async Task updateAsync(Secretaria secretaria)
        {
            this.contexto.Entry(secretaria).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }

        public async Task<Secretaria> getSecretaria(Expression<Func<Secretaria, bool>> expression)
        {
            return await this.contexto.Secretarias.Where(expression).FirstOrDefaultAsync();
        }
    }
}
