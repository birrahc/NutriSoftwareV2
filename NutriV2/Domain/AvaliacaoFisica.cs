using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriV2.Domain
{
    public class AvaliacaoFisica
    {
        public int Id { get; set; } 
        public int PacienteId { get; set; }
        public int NumAvaliacao { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public decimal ? Peso { get; set; }
        public decimal ? CircCintura { get; set; }
        public decimal ? CircAbdominal { get; set; }
        public decimal ? CircQuadril { get; set; }
        public decimal ? CircPeito { get; set; }
        public decimal ? CircBracoDireito { get; set; }
        public decimal ? CircBracoEsquerdo { get; set; }
        public decimal ? CircCoxadireita { get; set; }
        public decimal ? CircCoxaEsquerda { get; set; }
        public decimal ? CircPanturrilhaDireita { get; set; }
        public decimal ? CircPanturrilhaEsquerda { get; set; }
        public decimal ? DCTriceps { get; set; }
        public decimal ? DCEscapular { get; set; }
        public decimal ? DCSupraIliaca { get; set; }
        public decimal ? DCAbdominal { get; set; }
        public decimal ? DCAxilar { get; set; }
        public decimal ? DCPeitoral { get; set; }
        public decimal ? DCCoxa { get; set; }
        [NotMapped]
        public decimal PercentualGordura { get; set; }
        [NotMapped]
        public decimal MassaMuscular { get; set; }
        [NotMapped]
        public decimal Gordura { get; set; }
        public Paciente Paciente { get; set; }
        
    }
}