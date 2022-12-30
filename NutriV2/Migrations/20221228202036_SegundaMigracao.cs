using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriV2.Migrations
{
    public partial class SegundaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formacoes_Nutricionistas_NutricionistaId",
                table: "Formacoes");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Pagamentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Sexo",
                table: "Nutricionistas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NutricionistaId",
                table: "Formacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PacienteId",
                table: "Pagamentos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formacoes_Nutricionistas_NutricionistaId",
                table: "Formacoes",
                column: "NutricionistaId",
                principalTable: "Nutricionistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_PACIENTES_PacienteId",
                table: "Pagamentos",
                column: "PacienteId",
                principalTable: "PACIENTES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formacoes_Nutricionistas_NutricionistaId",
                table: "Formacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_PACIENTES_PacienteId",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_PacienteId",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Pagamentos");

            migrationBuilder.AlterColumn<int>(
                name: "Sexo",
                table: "Nutricionistas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NutricionistaId",
                table: "Formacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Formacoes_Nutricionistas_NutricionistaId",
                table: "Formacoes",
                column: "NutricionistaId",
                principalTable: "Nutricionistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
