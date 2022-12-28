using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class NutricionistaConfiguration : IEntityTypeConfiguration<Nutricionista>
    {
        public void Configure(EntityTypeBuilder<Nutricionista> builder)
        {
            builder.ToTable("Nutricionistas");
            builder.HasKey(p=>p.Id);
            builder.HasMany(p=>p.Formacoes);
        }
    }
}