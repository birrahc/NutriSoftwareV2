using System.Collections.Generic;

namespace NutriV2.Domain
{
    public class Formacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NutricionistaId { get; set; }
        public Nutricionista Nutricionista { get; set; }

    }
}