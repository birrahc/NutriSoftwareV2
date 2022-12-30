using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriV2.Migrations
{
    public partial class SegundaMigracaoObservacaoPacienteTitulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "AnotacosPaciente",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "AnotacosPaciente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "AnotacosPaciente");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "AnotacosPaciente",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
