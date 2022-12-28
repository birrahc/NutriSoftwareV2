using System.Collections.Generic;
using System;
namespace NutriV2.Domain
{
    public class Paciente : Pessoa
    {
         public int AnmineseId { get; set; }
        public ICollection<AvaliacaoFisica>  Avaliacoes { get; set; }
        public ICollection<Consulta>  Consultas { get; set; }
        public ICollection<Agenda> HorariosAgendados { get; set; }
    }
}