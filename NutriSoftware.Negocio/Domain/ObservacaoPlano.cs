using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSoftware.Negocio.Domain
{
    public class ObservacaoPlano
    {
        public int Id { get; set; }
        public string HorarioReferencia { get; set; }
        public string CodigoDieta { get; set; }
        public string Anotacoes { get; set; }
    }
}
