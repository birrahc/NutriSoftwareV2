using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriSoftware.Negocio.Domain;

namespace NutriSoftware.Negocio.Data.Configuration
{
    public class ObservacaoPlanoConfiguration : IEntityTypeConfiguration<ObservacaoPlano>
    {
        public void Configure(EntityTypeBuilder<ObservacaoPlano> builder)
        {
            builder.ToTable("ObservacaoPlano");
            builder.HasKey(p=>new { p.Id });
        }
    }
}