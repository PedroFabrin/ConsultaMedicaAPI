using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using InfraEstrutura.Data;

namespace InfraEstrutura.Data
{
    public class ContextoConsultaFactory : IDesignTimeDbContextFactory<ConsultaContexto>
    {
        public ConsultaContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConsultaContexto>();

            optionsBuilder.UseSqlServer(@"Server=localhost;
                DataBase=dbConsultaMedica;
                integrated security=true;TrustServerCertificate=True;");
            return new ConsultaContexto(optionsBuilder.Options);
        }
    }
}
