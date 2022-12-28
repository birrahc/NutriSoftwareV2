using System.ComponentModel.DataAnnotations.Schema;

namespace NutriV2.Domain
{
    public class Alimento
    {
       public int Id { get; set; } 
       public string Nome { get; set; }
       public decimal ? Calorias { get; set; }
        // public int DietaAlimentoId { get; set; }
        // public DietaAlimento DietaAlimento { get; set; }
    }
}