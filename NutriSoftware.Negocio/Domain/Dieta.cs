using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSoftware.Negocio.Domain
{
    public class Dieta
    {
        public string CodigoDieta { get; set; }
        public int PacienteId { get; set; }
        public DateTime Data { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<PlanoAlimentar> PlanosAlimentares { get; set; }
    }
}
