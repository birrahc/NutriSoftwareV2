using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriV2.Migrations
{
    public partial class primeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Calorias = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sexo = table.Column<int>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TipoDeContatoTelefone = table.Column<int>(nullable: true),
                    CRN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Sexo = table.Column<int>(type: "INT", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    Telefone = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    TipoDeContatoTelefone = table.Column<int>(nullable: true),
                    AnmineseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMedidas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeTipoMedida = table.Column<string>(type: "VARCHAR(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    NutricionistaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formacoes_Nutricionistas_NutricionistaId",
                        column: x => x.NutricionistaId,
                        principalTable: "Nutricionistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGENDA_PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "DATE", nullable: false),
                    Horario = table.Column<string>(type: "varchar(5)", nullable: false),
                    Status = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDA_PACIENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGENDA_PACIENTE_PACIENTES_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ANMINESE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false),
                    PacienteId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANMINESE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ANMINESE_PACIENTES_PacienteId1",
                        column: x => x.PacienteId1,
                        principalTable: "PACIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnotacosPaciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "AvaliacaoFisica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false),
                    NumAvaliacao = table.Column<int>(nullable: false),
                    DataAvaliacao = table.Column<DateTime>(nullable: false),
                    Peso = table.Column<double>(nullable: true),
                    CircCintura = table.Column<double>(nullable: true),
                    CircAbdominal = table.Column<double>(nullable: true),
                    CircQuadril = table.Column<double>(nullable: true),
                    CircPeito = table.Column<double>(nullable: true),
                    CircBracoDireito = table.Column<double>(nullable: true),
                    CircBracoEsquerdo = table.Column<double>(nullable: true),
                    CircCoxadireita = table.Column<double>(nullable: true),
                    CircCoxaEsquerda = table.Column<double>(nullable: true),
                    CircPanturrilhaDireita = table.Column<double>(nullable: true),
                    CircPanturrilhaEsquerda = table.Column<double>(nullable: true),
                    DCTriceps = table.Column<double>(nullable: true),
                    DCEscapular = table.Column<double>(nullable: true),
                    DCSupraIliaca = table.Column<double>(nullable: true),
                    DCAbdominal = table.Column<double>(nullable: true),
                    DCAxilar = table.Column<double>(nullable: true),
                    DCPeitoral = table.Column<double>(nullable: true),
                    DCCoxa = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoFisica_PACIENTES_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConsultaId = table.Column<int>(nullable: false),
                    TipoDePagamento = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_PACIENTES_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NutricionistaId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    AvaliacaoId = table.Column<int>(nullable: true),
                    PagamentoId = table.Column<int>(nullable: true),
                    DataConsulta = table.Column<DateTime>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_AvaliacaoFisica_AvaliacaoId",
                        column: x => x.AvaliacaoId,
                        principalTable: "AvaliacaoFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_Nutricionistas_NutricionistaId",
                        column: x => x.NutricionistaId,
                        principalTable: "Nutricionistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_PACIENTES_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Pagamentos_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_PACIENTE_PacienteId",
                table: "AGENDA_PACIENTE",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ANMINESE_PacienteId1",
                table: "ANMINESE",
                column: "PacienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacosPaciente_PacienteId",
                table: "AnotacosPaciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoFisica_PacienteId",
                table: "AvaliacaoFisica",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_AvaliacaoId",
                table: "Consulta",
                column: "AvaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_NutricionistaId",
                table: "Consulta",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PagamentoId",
                table: "Consulta",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Formacoes_NutricionistaId",
                table: "Formacoes",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PacienteId",
                table: "Pagamentos",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDA_PACIENTE");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "ANMINESE");

            migrationBuilder.DropTable(
                name: "AnotacosPaciente");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Formacoes");

            migrationBuilder.DropTable(
                name: "TipoMedidas");

            migrationBuilder.DropTable(
                name: "AvaliacaoFisica");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Nutricionistas");

            migrationBuilder.DropTable(
                name: "PACIENTES");
        }
    }
}
