using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.Eventos.Domain.Organizadores;
using TMSA.Eventos.Infra.Data.Extensions;

namespace TMSA.Eventos.Infra.Data.Mapping
{
    public class OrganizadorMapping : EntityTypeconfigurations<Organizador>
    {
        public override void Map(EntityTypeBuilder<Organizador> builder)
        {
            builder.Property(e => e.Nome)
              .HasColumnType("varchar(150)")
              .IsRequired();

            builder.Property(e => e.Email)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(e => e.CPF)
               .HasColumnType("varchar(11)")
               .HasMaxLength(11)
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Organizadores");

        }
    }
}