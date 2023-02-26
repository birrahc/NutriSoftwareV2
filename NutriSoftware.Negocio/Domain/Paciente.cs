using System.Collections.Generic;
using System;
namespace NutriSoftware.Negocio.Domain
{
    public class Paciente : Pessoa
    {
        public string Profissao { get; set; }
        //public ICollection<AvaliacaoFisica>  Avaliacoes { get; set; }
        //public ICollection<Consulta>Consultas { get; set; }
        //public ICollection<Agenda> HorariosAgendados { get; set; }
        //public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<AnotacoesPaciente>Anotacoes { get; set; }
        
    }
}