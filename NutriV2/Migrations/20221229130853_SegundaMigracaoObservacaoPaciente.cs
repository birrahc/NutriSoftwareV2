using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriV2.Migrations
{
    public partial class SegundaMigracaoObservacaoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_AvaliacaoFisica_AvaliacaoId",
                table: "Consulta");

            migrationBuilder.AlterColumn<int>(
                name: "AvaliacaoId",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AnotacosPaciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false),
                    Anotacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacosPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotacosPaciente_PACIENTES_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnotacosPaciente_PacienteId",
                table: "AnotacosPaciente",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_AvaliacaoFisica_AvaliacaoId",
                table: "Consulta",
                column: "AvaliacaoId",
                principalTable: "AvaliacaoFisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_AvaliacaoFisica_AvaliacaoId",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "AnotacosPaciente");

            migrationBuilder.AlterColumn<int>(
                name: "AvaliacaoId",
                table: "Consulta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_AvaliacaoFisica_AvaliacaoId",
                table: "Consulta",
                column: "AvaliacaoId",
                principalTable: "AvaliacaoFisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
