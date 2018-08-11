using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.Eventos.Domain.Eventos;
using TMSA.Eventos.Infra.Data.Extensions;

namespace TMSA.Eventos.Infra.Data.Mapping
{
    public class EnderecoMapping : EntityTypeconfigurations<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.Ignore(c => c.CascadeMode);

            builder.Ignore(c => c.ValidationResult);

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Numero)
                .IsRequired();

            builder.Property(c => c.Complemento)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Estado)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.HasOne(e => e.Evento)
                 .WithOne(ev => ev.Endereco)
                 .HasForeignKey<Endereco>(e => e.EventoId);

            builder.ToTable("Enderecos");
        }
    }
}