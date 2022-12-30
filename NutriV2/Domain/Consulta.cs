namespace NutriV2.Domain
{
    public class Consulta
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int ? AvaliacaoId { get; set; }
        public Paciente Paciente { get; set; }
        public AvaliacaoFisica Avaliacao { get; set; }
    }
}