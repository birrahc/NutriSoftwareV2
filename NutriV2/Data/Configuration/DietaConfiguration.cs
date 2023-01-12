
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class DietaConfiguration : IEntityTypeConfiguration<Dieta>
    {
        public void Configure(EntityTypeBuilder<Dieta> builder)
        {
            builder.ToTable("Dietas");
            builder.HasKey(p=>p.CodigoDieta);
            builder.Property(p=>p.Anotacoes).HasColumnType("TEXT");
            builder.Property(p => p.CodigoDieta).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.CodigoDieta).ValueGeneratedNever();

            builder.HasMany(p => p.HoraAlimentos)
                .WithOne(p => p.Dieta)
                .HasForeignKey(p=>p.CodigoDieta)
                .OnDelete(DeleteBehavior.Cascade);

            // // builder.HasOne(p=>p.Anminese)
            // //      .WithOne(p=>p.Paciente)
            // //      .OnDelete(DeleteBehavior.Cascade);

            // builder.HasMany(p=>p.Consultas)
            //         .WithOne(p=>p.Paciente)

            //         .OnDelete(DeleteBehavior.Cascade);

            // builder.HasMany(p=>p.Dietas)
            //     .WithOne(p=>p.Paciente)
            //     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}