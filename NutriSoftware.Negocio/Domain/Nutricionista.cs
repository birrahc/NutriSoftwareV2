using System.Collections.Generic;

namespace NutriSoftware.Negocio.Domain
{
    public class Nutricionista : Pessoa
    {
        public string CRN{ get; set; }
        public ICollection<Formacao> Formacoes { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }   
}