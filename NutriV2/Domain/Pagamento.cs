using NutriV2.Enums;
using System;

namespace NutriV2.Domain
{
    public class Pagamento
    {
      public int Id { get; set; }  
      public int ConsultaId { get; set; }
      public EN_TipoPagamento TipoDePagamento { get; set; }
      public DateTime Data { get; set; }
    //   public Consulta ? Consulta { get; set; }
      public DateTime ? DataVencimento { get; set; }
    }
}