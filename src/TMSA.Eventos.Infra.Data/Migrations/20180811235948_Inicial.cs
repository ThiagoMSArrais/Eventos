using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMSA.Eventos.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    DescricaoCurta = table.Column<string>(nullable: true),
                    DescricaoLonga = table.Column<string>(nullable: true),
                    DataInicioDoEvento = table.Column<DateTime>(nullable: false),
                    DataFimDoEvento = table.Column<DateTime>(nullable: false),
                    Online = table.Column<bool>(nullable: false),
                    Gratuito = table.Column<bool>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    NomeDaEmpresa = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    EnderecoId = table.Column<Guid>(nullable: true),
                    OrganizadorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Organizadores_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    EventoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EventoId",
                table: "Enderecos",
                column: "EventoId",
                unique: true,
                filter: "[EventoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_OrganizadorId",
                table: "Eventos",
                column: "OrganizadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Organizadores");
        }
    }
}
