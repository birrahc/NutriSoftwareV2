using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class AnmineseConfiguration : IEntityTypeConfiguration<Anminese>
    {
        public void Configure(EntityTypeBuilder<Anminese> builder)
        {
            builder.ToTable("ANMINESE");
            builder.HasKey(p=>p.Id);

            //builder.HasOne(p=>p.Paciente)
            // .WithOne(p=>p.Anminese);
        }
    }
}