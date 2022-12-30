using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class AnotacoesPacienteConfiguration : IEntityTypeConfiguration<AnotacoesPaciente>
    {
        public void Configure(EntityTypeBuilder<AnotacoesPaciente> builder)
        {
            builder.HasKey(p=>new{p.Id});
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();
        }
    }
}