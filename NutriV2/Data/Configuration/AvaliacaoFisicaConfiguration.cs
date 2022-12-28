using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class AvaliacaoFisicaConfiguration : IEntityTypeConfiguration<AvaliacaoFisica>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoFisica> builder)
        {
            builder.ToTable("AvaliacaoFisica");
            builder.HasKey(p=>p.Id);

             builder.HasOne(p=>p.Paciente)
              .WithMany(p=>p.Avaliacoes)
              .HasForeignKey(p=>p.PacienteId);

        }
    }
}