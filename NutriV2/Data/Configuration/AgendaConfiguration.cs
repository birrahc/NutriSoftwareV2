using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriV2.Domain;

namespace NutriV2.Data.Configuration
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
           builder.ToTable("AGENDA_PACIENTE");
           builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Data).HasColumnType("DATE").IsRequired();
            builder.Property(p=>p.Horario).HasColumnType("varchar(5)").IsRequired();
            builder.Property(p=>p.Status).HasColumnType("INT").IsRequired();

            builder.HasOne(p=>p.Paciente)
                .WithMany(p=>p.HorariosAgendados)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}