using System;
using System.Collections.Generic;
using System.Text;

namespace NutriV2.Domain
{
    public class QuantidadeAlimento
    {
        public int Id { get; set; }
        public string CodigoDieta { get; set; }
        public int AlimentoId { get; set; }
        public int TipoMedidaId { get; set; }
        public decimal quantidade { get; set; }
        public TipoMedida TipoMedia { get; set; }
        public Alimento Alimento { get; set; }
        public Dieta Dieta { get; set; }
    }
}
