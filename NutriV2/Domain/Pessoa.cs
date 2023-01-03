
using System;
using NutriV2.Enums;
using NutriV2.Svc;

namespace NutriV2.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public EN_Sexo ? Sexo{ get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { 
            get{
                int idade = DateTime.Now.Year - this.Nascimento.Year;
                if (DateTime.Now.DayOfYear < this.Nascimento.DayOfYear)
                    idade = idade - 1;
                return idade;
            } 
        }
        public string  CPF { get; set; }
        public string  Email { get; set; }
        public string  Telefone { get; set; }
        public EN_TipoDeContatoTelefone ? TipoDeContatoTelefone { get; set; }
        public string TipoTelefoneGetDescription { get => SvcEnum.GetDescription(this.TipoDeContatoTelefone); }

    }
}