using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consulta");
            builder.HasKey(p=>new{p.Id});
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Dieta)
                .WithOne();
                
            
        }
    }
}