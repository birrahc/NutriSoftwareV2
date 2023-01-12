using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriV2.Domain
{
    public class Dieta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CodigoDieta { get; set; }
        public string Anotacoes { get; set; }
        public ICollection<HoraAlimentos> HoraAlimentos { get; set; }
    }
}