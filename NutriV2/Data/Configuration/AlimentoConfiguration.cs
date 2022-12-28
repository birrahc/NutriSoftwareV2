using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class AlimentoConfiguration : IEntityTypeConfiguration<Alimento>
    {
        public void Configure(EntityTypeBuilder<Alimento> builder)
        {
            builder.ToTable("Alimentos");
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Calorias).HasColumnType("DECIMAL(10,2)");
        }
    }
}