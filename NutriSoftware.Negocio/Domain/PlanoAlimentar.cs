using NutriSoftware.Negocio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSoftware.Negocio.Domain
{
    public class PlanoAlimentar
    {
        //public int PacienteId { get; set; }
        public string CodigoDieta { get; set; }
        public string HoraAlimentos { get; set; }
        public int ? ObservacaoPlanoId { get; set; }
        public virtual ICollection<QuantidadeAlimento> QuantidadeAlimentos { get; set; }
        public virtual ObservacaoPlano ObservacaoPlano { get; set; }

     
    }
}
