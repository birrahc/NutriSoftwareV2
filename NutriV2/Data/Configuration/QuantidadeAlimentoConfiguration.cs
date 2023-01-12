
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class QuantidadeAlimentoConfiguration : IEntityTypeConfiguration<QuantidadeAlimento>
    {
        public void Configure(EntityTypeBuilder<QuantidadeAlimento> builder)
        {
            builder.ToTable("QuantidadeAlimento");
            builder.HasKey(p=> new { p.Id, p.CodigoDieta });
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CodigoDieta).HasColumnType("VARCHAR(50)");
        }
    }
}