
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class HoraAlimentosConfiguration : IEntityTypeConfiguration<HoraAlimentos>
    {
        public void Configure(EntityTypeBuilder<HoraAlimentos> builder)
        {
            builder.ToTable("HoraAlimentos");
            builder.HasKey(p=>new { p.Id, p.CodigoDieta });
            builder.Property(p=>p.Hora).HasColumnType("VARCHAR(5)").IsRequired();
            builder.Property(p=>p.Observacao).HasColumnType("TEXT").IsRequired();
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CodigoDieta).HasColumnType("VARCHAR(50)");

        }
    }
}