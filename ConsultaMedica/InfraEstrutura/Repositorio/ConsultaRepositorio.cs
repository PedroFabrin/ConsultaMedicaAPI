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
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private ConsultaContexto contexto;

        public ConsultaRepositorio(ConsultaContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Consulta> addAsync(Consulta consulta)
        {
            await this.contexto.Consultas.AddAsync(consulta);
            await this.contexto.SaveChangesAsync();
            return consulta;
        }

        public async Task<IEnumerable<Consulta>> getAllAsync(Expression<Func<Consulta, bool>> expression)
        {
            return await this.contexto.Consultas.Where(expression).OrderBy(p => p.dataConsulta).ToListAsync();
        }

        public async Task<Consulta?> getAsync(int id)
        {
            return await this.contexto.Consultas.FindAsync(id);
        }

        public async Task removeAsync(Consulta categoria)
        {
            this.contexto.Consultas.Remove(categoria);
            await this.contexto.SaveChangesAsync();

        }

        public async Task updateAsync(Consulta consulta)
        {
            this.contexto.Entry(consulta).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }
    }
}
