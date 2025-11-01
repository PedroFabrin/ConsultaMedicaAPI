using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Data
{
    public class ConsultaContexto:DbContext
    {
        public ConsultaContexto(
            DbContextOptions<ConsultaContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas {  get; set; }
        public DbSet<Secretaria> Secretarias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(builder =>
            {
                builder.Property(p => p.Nome).IsRequired();
                builder.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Medico>(builder => { 
                builder.Property(p => p.Nome).IsRequired();
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Especialidade).IsRequired();
            });

            modelBuilder.Entity<Consulta>(builder =>
            {
                builder.Property(p => p.dataConsulta).IsRequired();
                builder.HasKey(p => p.Id);
                builder.HasOne(p => p.usuario) //lado um
                .WithMany(p => p.consultas) //lado muitos
                .HasForeignKey(p => p.IdUsuario) //chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(p => p.medico)
                .WithMany(p => p.consultas)
                .HasForeignKey(p => p.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Secretaria>(builder =>
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.senha).IsRequired().HasMaxLength(15);
                builder.Property(p => p.Nome).IsRequired();
                builder.Property(p => p.email).IsRequired().HasMaxLength(50);
            });
        }
    }

}
