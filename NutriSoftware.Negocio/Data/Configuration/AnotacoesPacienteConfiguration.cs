using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriSoftware.Negocio.Domain;

namespace NutriSoftware.Negocio.Data.Configuration
{
    public class AnotacoesPacienteConfiguration : IEntityTypeConfiguration<AnotacoesPaciente>
    {
        public void Configure(EntityTypeBuilder<AnotacoesPaciente> builder)
        {
            builder.ToTable("Observacao");
            builder.HasKey(p=>new{p.Id});
            
        }
    }
}