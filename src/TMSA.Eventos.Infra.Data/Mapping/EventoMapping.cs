using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.Eventos.Domain.Eventos;
using TMSA.Eventos.Infra.Data.Extensions;

namespace TMSA.Eventos.Infra.Data.Mapping
{
    public class EventoMapping : EntityTypeconfigurations<Evento>
    {
        public override void Map(EntityTypeBuilder<Evento> builder)
        {
            builder.Ignore(c => c.CascadeMode);

            builder.Ignore(c => c.ValidationResult);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.DataInicioDoEvento)
                .IsRequired();

            builder.Property(c => c.DataFimDoEvento)
                .IsRequired();

            builder.Property(c => c.Gratuito)
                .IsRequired();

            builder.Property(c => c.NomeDaEmpresa)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Online)
                .IsRequired();

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.HasOne(o => o.Organizador)
                .WithMany(e => e.Eventos)
                .HasForeignKey(o => o.OrganizadorId);

            builder.ToTable("Eventos");
        }
    }
}
