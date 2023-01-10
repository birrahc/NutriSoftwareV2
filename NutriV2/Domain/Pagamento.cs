using NutriV2.Enums;
using System;
using System.Collections.Generic;

namespace NutriV2.Domain
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public EN_TipoPagamento TipoDePagamento { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
       
    }
}