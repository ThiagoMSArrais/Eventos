﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMSA.Eventos.Infra.Data.Context;

namespace TMSA.Eventos.Infra.Data.Migrations
{
    [DbContext(typeof(EventoContext))]
    [Migration("20180811235948_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TMSA.Eventos.Domain.Eventos.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<Guid?>("EventoId");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventoId")
                        .IsUnique()
                        .HasFilter("[EventoId] IS NOT NULL");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("TMSA.Eventos.Domain.Eventos.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFimDoEvento");

                    b.Property<DateTime>("DataInicioDoEvento");

                    b.Property<string>("DescricaoCurta");

                    b.Property<string>("DescricaoLonga");

                    b.Property<Guid?>("EnderecoId");

                    b.Property<bool>("Gratuito");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("NomeDaEmpresa")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("Online");

                    b.Property<Guid?>("OrganizadorId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("TMSA.Eventos.Domain.Organizadores.Organizador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Organizadores");
                });

            modelBuilder.Entity("TMSA.Eventos.Domain.Eventos.Endereco", b =>
                {
                    b.HasOne("TMSA.Eventos.Domain.Eventos.Evento", "Evento")
                        .WithOne("Endereco")
                        .HasForeignKey("TMSA.Eventos.Domain.Eventos.Endereco", "EventoId");
                });

            modelBuilder.Entity("TMSA.Eventos.Domain.Eventos.Evento", b =>
                {
                    b.HasOne("TMSA.Eventos.Domain.Organizadores.Organizador", "Organizador")
                        .WithMany("Eventos")
                        .HasForeignKey("OrganizadorId");
                });
#pragma warning restore 612, 618
        }
    }
}
