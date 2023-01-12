using NutriV2.Domain;
using NutriV2.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace Data.NutriDbContext
{
    public class NutriDbContext : DbContext
    {
        public DbSet<Agenda> Agenda{get ; set;}
        public DbSet<Alimento> Alimentos{get ; set;}
        public DbSet<Anminese> Anminese{get ; set;}
        public DbSet<AnotacoesPaciente> AnotacosPaciente{get ; set;}
        public DbSet<AvaliacaoFisica> AvaliacoesFisicas{get ; set;}
        public DbSet<Consulta> Consultas{get ; set;}
        public DbSet<Formacao> Formacoes{get ; set;}
        public DbSet<Nutricionista> Nutricionistas{get ; set;}
        public DbSet<Paciente> pacientes{get ; set;}
        public DbSet<Pagamento> Pagamentos{get ; set;}
        public DbSet<TipoMedida> TipoMedidas{get ; set;}
        public DbSet<Dieta> Dieta{get ; set;}
        public DbSet<HoraAlimentos> HoraAlimentos{get ; set;}
        public DbSet<QuantidadeAlimento> QuandadeAlimento{get ; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            //var connetionString = Configuration.GetConnectionString("DefaultConnection");
            //options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            optionsBuilder
            .UseMySql("Server = localhost; Database=NutriV2 ; Uid = root; Pwd = 123456;"); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //  modelBuilder.Entity<DietaAlimento>()
            //      .HasOne<Dieta>(s=>s.Dieta)
            //      .WithMany(d=>d.Alimentos)
            //      .HasForeignKey(f=>f.AlimentoId);
                
            //modelBuilder.ApplyConfiguration(new AnmineseConfiguration());
            // modelBuilder.ApplyConfiguration(new AgendaConfiguration());
            // modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            // modelBuilder.ApplyConfiguration(new AlimentoConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NutriDbContext).Assembly);
        }
    }
}