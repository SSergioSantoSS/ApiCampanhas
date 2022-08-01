using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjCampanhas.Infra.Data.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PeriodoInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodoFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValordoInvestimento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QntHoras = table.Column<int>(type: "int", nullable: false),
                    TipoDeCampanha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_Codigo",
                table: "Campanhas",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_Nome",
                table: "Campanhas",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campanhas");
        }
    }
}
