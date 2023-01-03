using NutriV2.Svc;
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
        public decimal? Peso { get; set; }
        public decimal? CircCintura { get; set; }
        public decimal? CircAbdominal { get; set; }
        public decimal? CircQuadril { get; set; }
        public decimal? CircPeito { get; set; }
        public decimal? CircBracoDireito { get; set; }
        public decimal? CircBracoEsquerdo { get; set; }
        public decimal? CircCoxadireita { get; set; }
        public decimal? CircCoxaEsquerda { get; set; }
        public decimal? CircPanturrilhaDireita { get; set; }
        public decimal? CircPanturrilhaEsquerda { get; set; }
        public decimal? DCTriceps { get; set; }
        public decimal? DCEscapular { get; set; }
        public decimal? DCSupraIliaca { get; set; }
        public decimal? DCAbdominal { get; set; }
        public decimal? DCAxilar { get; set; }
        public decimal? DCPeitoral { get; set; }
        public decimal? DCCoxa { get; set; }
        public Paciente Paciente { get; set; }

        [NotMapped]
        private double? SomatoriaDc
        {
            get
            {
                if (this.DCTriceps.HasValue &&
                      this.DCEscapular.HasValue &&
                      this.DCSupraIliaca.HasValue &&
                      this.DCAbdominal.HasValue &&
                      this.DCAxilar.HasValue &&
                      this.DCPeitoral.HasValue &&
                      this.DCCoxa.HasValue)
                {
                   return Convert.ToDouble((
                        this.DCTriceps +
                        this.DCEscapular +
                        this.DCSupraIliaca +
                        this.DCAbdominal +
                        this.DCAxilar +
                        this.DCPeitoral +
                        this.DCCoxa
                        ));
                    
                }
                return null;
            }
        }

       
        [NotMapped]
        private double ? Densidade {
            get { 
                if(this.SomatoriaDc.HasValue && this.Paciente.Sexo.HasValue && this.Paciente.Idade > 0)
                    return SvcAvaliacao.CalculularDensidade(this.SomatoriaDc.Value, this.Paciente.Sexo.Value, this.Paciente.Idade).Value;
                return null;
            }
        }

        [NotMapped]
        public decimal ? PercentualGordura { 
            get {
                if (this.Densidade.HasValue)
                    return (decimal)SvcAvaliacao.CalcularPercentualGordura(this.Densidade.Value);
                return null;
            } 
        }
        [NotMapped]
        public decimal ? MassaMuscular {
            get {
                if(this.PercentualGordura.HasValue && this.Peso.HasValue)
                    return (decimal)SvcAvaliacao.CalcularMassaMuscular((double)this.PercentualGordura, (double)this.Peso);
                return null;
            }
        }
        [NotMapped]
        public decimal ? Gordura { 
            get {
                if(this.PercentualGordura.HasValue && this.Peso.HasValue)
                    return (decimal)SvcAvaliacao.CalcularGordura((double)this.PercentualGordura.Value, (double)this.Peso.Value);
                return null;
            }
        }
        

    }
}