using System;
using System.Collections.Generic;
using System.Text;

namespace NutriV2.Domain
{
    public class HoraAlimentos
    {
        public int Id { get; set; }
        public string CodigoDieta { get; set; }
        public string Hora { get; set; }
        public string Observacao { get; set; }
        public Dieta Dieta { get; set; }
        public ICollection<QuantidadeAlimento> QuantidadeAlimento { get; set; }
    }
}
