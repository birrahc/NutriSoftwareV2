using System;
using NutriV2.Enums;

namespace NutriV2.Domain
{
    public class Agenda
    {
        public int Id { get; set; }
        public int PacienteId { get; set; } 
        public DateTime Data { get; set; }
        public string Horario { get; set; }
        public Paciente Paciente { get; set; }
        public EN_StatusAgenda Status { get; set; } 
        
    }
}