using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class FormacaoConfiguration : IEntityTypeConfiguration<Formacao>
    {
        public void Configure(EntityTypeBuilder<Formacao> builder)
        {
            builder.ToTable("Formacoes");
            builder.HasKey(p=>p.Id);
            //builder.HasMany(p=>p.Nutricionistas);
            
            
        }
    }
}