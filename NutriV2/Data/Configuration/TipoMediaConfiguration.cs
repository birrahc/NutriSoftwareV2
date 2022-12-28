using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class TipoMediaConfiguration : IEntityTypeConfiguration<TipoMedida>
    {
        public void Configure(EntityTypeBuilder<TipoMedida> builder)
        {
            builder.ToTable("TipoMedidas");
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.NomeTipoMedida).HasColumnType("VARCHAR(40)");
        }
    }
}