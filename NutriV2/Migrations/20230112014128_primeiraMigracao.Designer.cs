﻿// <auto-generated />
using System;
using Data.NutriDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace NutriV2.Migrations
{
    [DbContext(typeof(NutriDbContext))]
    [Migration("20230112014128_primeiraMigracao")]
    partial class primeiraMigracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NutriV2.Domain.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DATE");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("AGENDA_PACIENTE");
                });

            modelBuilder.Entity("NutriV2.Domain.Alimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal?>("Calorias")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Alimentos");
                });

            modelBuilder.Entity("NutriV2.Domain.Anminese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("PacienteId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId1");

                    b.ToTable("ANMINESE");
                });

            modelBuilder.Entity("NutriV2.Domain.AnotacoesPaciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Anotacoes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("AnotacosPaciente");
                });

            modelBuilder.Entity("NutriV2.Domain.AvaliacaoFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double?>("CircAbdominal")
                        .HasColumnType("double");

                    b.Property<double?>("CircBracoDireito")
                        .HasColumnType("double");

                    b.Property<double?>("CircBracoEsquerdo")
                        .HasColumnType("double");

                    b.Property<double?>("CircCintura")
                        .HasColumnType("double");

                    b.Property<double?>("CircCoxaEsquerda")
                        .HasColumnType("double");

                    b.Property<double?>("CircCoxadireita")
                        .HasColumnType("double");

                    b.Property<double?>("CircPanturrilhaDireita")
                        .HasColumnType("double");

                    b.Property<double?>("CircPanturrilhaEsquerda")
                        .HasColumnType("double");

                    b.Property<double?>("CircPeito")
                        .HasColumnType("double");

                    b.Property<double?>("CircQuadril")
                        .HasColumnType("double");

                    b.Property<double?>("DCAbdominal")
                        .HasColumnType("double");

                    b.Property<double?>("DCAxilar")
                        .HasColumnType("double");

                    b.Property<double?>("DCCoxa")
                        .HasColumnType("double");

                    b.Property<double?>("DCEscapular")
                        .HasColumnType("double");

                    b.Property<double?>("DCPeitoral")
                        .HasColumnType("double");

                    b.Property<double?>("DCSupraIliaca")
                        .HasColumnType("double");

                    b.Property<double?>("DCTriceps")
                        .HasColumnType("double");

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumAvaliacao")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<double?>("Peso")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("AvaliacaoFisica");
                });

            modelBuilder.Entity("NutriV2.Domain.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DietaId")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("NutricionistaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("PagamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AvaliacaoId");

                    b.HasIndex("DietaId")
                        .IsUnique();

                    b.HasIndex("NutricionistaId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("NutriV2.Domain.Dieta", b =>
                {
                    b.Property<string>("CodigoDieta")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Anotacoes")
                        .HasColumnType("TEXT");

                    b.HasKey("CodigoDieta");

                    b.ToTable("Dietas");
                });

            modelBuilder.Entity("NutriV2.Domain.Formacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NutricionistaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NutricionistaId");

                    b.ToTable("Formacoes");
                });

            modelBuilder.Entity("NutriV2.Domain.HoraAlimentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoDieta")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id", "CodigoDieta");

                    b.HasIndex("CodigoDieta");

                    b.ToTable("HoraAlimentos");
                });

            modelBuilder.Entity("NutriV2.Domain.Nutricionista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CRN")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("TipoDeContatoTelefone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nutricionistas");
                });

            modelBuilder.Entity("NutriV2.Domain.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnmineseId")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("DATE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.Property<int>("Sexo")
                        .HasColumnType("INT");

                    b.Property<string>("Telefone")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<int?>("TipoDeContatoTelefone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PACIENTES");
                });

            modelBuilder.Entity("NutriV2.Domain.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConsultaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDePagamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("NutriV2.Domain.QuantidadeAlimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoDieta")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("AlimentoId")
                        .HasColumnType("int");

                    b.Property<string>("HoraAlimentosCodigoDieta")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("HoraAlimentosId")
                        .HasColumnType("int");

                    b.Property<int>("TipoMedidaId")
                        .HasColumnType("int");

                    b.Property<decimal>("quantidade")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id", "CodigoDieta");

                    b.HasIndex("AlimentoId");

                    b.HasIndex("CodigoDieta");

                    b.HasIndex("TipoMedidaId");

                    b.HasIndex("HoraAlimentosId", "HoraAlimentosCodigoDieta");

                    b.ToTable("QuantidadeAlimento");
                });

            modelBuilder.Entity("NutriV2.Domain.TipoMedida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeTipoMedida")
                        .HasColumnType("VARCHAR(40)");

                    b.HasKey("Id");

                    b.ToTable("TipoMedidas");
                });

            modelBuilder.Entity("NutriV2.Domain.Agenda", b =>
                {
                    b.HasOne("NutriV2.Domain.Paciente", "Paciente")
                        .WithMany("HorariosAgendados")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutriV2.Domain.Anminese", b =>
                {
                    b.HasOne("NutriV2.Domain.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId1");
                });

            modelBuilder.Entity("NutriV2.Domain.AnotacoesPaciente", b =>
                {
                    b.HasOne("NutriV2.Domain.Paciente", "Paciente")
                        .WithMany("Anotacoes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutriV2.Domain.AvaliacaoFisica", b =>
                {
                    b.HasOne("NutriV2.Domain.Paciente", "Paciente")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutriV2.Domain.Consulta", b =>
                {
                    b.HasOne("NutriV2.Domain.AvaliacaoFisica", "Avaliacao")
                        .WithMany()
                        .HasForeignKey("AvaliacaoId");

                    b.HasOne("NutriV2.Domain.Dieta", "Dieta")
                        .WithOne()
                        .HasForeignKey("NutriV2.Domain.Consulta", "DietaId");

                    b.HasOne("NutriV2.Domain.Nutricionista", "Nutricionista")
                        .WithMany("Consultas")
                        .HasForeignKey("NutricionistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriV2.Domain.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriV2.Domain.Pagamento", "Pagamento")
                        .WithMany("Consulta")
                        .HasForeignKey("PagamentoId");
                });

            modelBuilder.Entity("NutriV2.Domain.Formacao", b =>
                {
                    b.HasOne("NutriV2.Domain.Nutricionista", "Nutricionista")
                        .WithMany("Formacoes")
                        .HasForeignKey("NutricionistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutriV2.Domain.HoraAlimentos", b =>
                {
                    b.HasOne("NutriV2.Domain.Dieta", "Dieta")
                        .WithMany("HoraAlimentos")
                        .HasForeignKey("CodigoDieta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutriV2.Domain.Pagamento", b =>
                {
                    b.HasOne("NutriV2.Domain.Paciente", "Paciente")
                        .WithMany("Pagamentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutriV2.Domain.QuantidadeAlimento", b =>
                {
                    b.HasOne("NutriV2.Domain.Alimento", "Alimento")
                        .WithMany()
                        .HasForeignKey("AlimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriV2.Domain.Dieta", "Dieta")
                        .WithMany()
                        .HasForeignKey("CodigoDieta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriV2.Domain.TipoMedida", "TipoMedia")
                        .WithMany()
                        .HasForeignKey("TipoMedidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriV2.Domain.HoraAlimentos", null)
                        .WithMany("QuantidadeAlimento")
                        .HasForeignKey("HoraAlimentosId", "HoraAlimentosCodigoDieta");
                });
#pragma warning restore 612, 618
        }
    }
}
