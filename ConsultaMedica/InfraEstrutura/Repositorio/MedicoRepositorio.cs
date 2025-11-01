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
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private ConsultaContexto contexto;

        public MedicoRepositorio(ConsultaContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Medico> addAsync(Medico medico)
        {
            await this.contexto.Medicos.AddAsync(medico);
            await this.contexto.SaveChangesAsync();
            return medico;
        }

        public async Task<IEnumerable<Medico>> getAllAsync(Expression<Func<Medico, bool>> expression)
        {
            return await this.contexto.Medicos.Where(expression).OrderBy(p => p.Especialidade).ToListAsync();
        }

        public async Task<Medico?> getAsync(int id)
        {
            return await this.contexto.Medicos.FindAsync(id);
        }

        public async Task removeAsync(Medico medico)
        {
            this.contexto.Medicos.Remove(medico);
            await this.contexto.SaveChangesAsync();

        }

        public async Task updateAsync(Medico medico)
        {
            this.contexto.Entry(medico).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }
    }
}
