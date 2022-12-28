namespace NutriV2.Domain
{
    public class Anminese
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}