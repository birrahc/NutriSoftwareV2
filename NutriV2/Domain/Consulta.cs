using System;

namespace NutriV2.Domain
{
    public class Consulta
    {
        public int Id { get; set; }
        public int NutricionistaId { get; set; }
        public int PacienteId { get; set; }
        public int ? AvaliacaoId { get; set; }
        public int ? PagamentoId { get; set; }
        public DateTime DataConsulta { get; set; }
        public Nutricionista Nutricionista { get; set;}
        public Paciente Paciente { get; set; }
        public AvaliacaoFisica Avaliacao { get; set; }
        public Pagamento Pagamento { get; set; }
        public string Observacoes { get; set; }
        
    }
}