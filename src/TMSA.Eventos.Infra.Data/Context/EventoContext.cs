using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TMSA.Eventos.Domain.Eventos;
using TMSA.Eventos.Infra.Data.Extensions;
using TMSA.Eventos.Infra.Data.Mapping;
using System.IO;
using TMSA.Eventos.Domain.Organizadores;

namespace TMSA.Eventos.Infra.Data.Context
{
    public class EventoContext : DbContext
    {
        public DbSet<Evento> Eventos { get; private set; }
        public DbSet<Endereco> Enderecos { get; private set; }
        public DbSet<Organizador> Organizadores { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EventoMapping());
            modelBuilder.AddConfiguration(new EnderecoMapping());
            modelBuilder.AddConfiguration(new OrganizadorMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}