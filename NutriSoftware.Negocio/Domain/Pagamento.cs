using NutriSoftware.Negocio.Enums;
using System;
using System.Collections.Generic;

namespace NutriSoftware.Negocio.Domain
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public EN_TipoPlano TipoPlano { get; set; }
        public EN_TipoPlano TipoConsulta { get; set; }
        public decimal Valor { get; set; }
        public int NumeroParcelas { get; set; }
        public decimal ValorParcelas { get; set; }
        public DateTime DataPagamento { get; set; }
        public EN_StatusPagamento StatusPagamento { get; set; }
        public string Observacao { get; set; }
        public ICollection<Consulta> Consulta { get; set; }

    }
}