using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriSoftware.Negocio.Domain;

namespace NutriSoftware.Negocio.Data.Configuration
{
    public class TipoMediaConfiguration : IEntityTypeConfiguration<TipoMedida>
    {
        public void Configure(EntityTypeBuilder<TipoMedida> builder)
        {
            builder.ToTable("TipoMedida");
            builder.HasKey(p=>p.Id);
        }
    }
}