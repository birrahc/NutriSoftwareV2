using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriV2.Migrations
{
    public partial class SegundaMigracaoObservacaoPacienteData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "AnotacosPaciente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "AnotacosPaciente");
        }
    }
}
