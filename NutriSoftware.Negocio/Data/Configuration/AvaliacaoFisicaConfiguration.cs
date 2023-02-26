using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriSoftware.Negocio.Domain;

namespace NutriSoftware.Negocio.Data.Configuration
{
    public class AvaliacaoFisicaConfiguration : IEntityTypeConfiguration<AvaliacaoFisica>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoFisica> builder)
        {
            builder.ToTable("AvaliacaoFisica");
            builder.HasKey(p=>p.Id);

        }
    }
}