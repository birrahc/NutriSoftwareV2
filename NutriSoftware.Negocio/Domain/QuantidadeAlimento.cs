using NutriSoftware.Negocio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSoftware.Negocio.Domain
{
    public class QuantidadeAlimento
    {
        public string CodigoDieta { get; set; }
        public string Hora { get; set; }
        public int AlimentoId { get; set; }
        public int TipoMedidaId { get; set; }
        public float Quantidade { get; set; }
        public EN_TipoDietaAlimentos Tipo { get; set; }
        public virtual TipoMedida TipoMedida { get; set; }
        public virtual AlimentoBebida Alimento { get; set; }
        public virtual PlanoAlimentar PlanoAlimentar{ get; set; }

    }
}


