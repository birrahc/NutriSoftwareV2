using System;
using Data.NutriDbContext;
using NutriV2.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NutriV2
{
    class Program
    {
        static void Main(string[] args)
        {
           NutriDbContext db = new NutriDbContext();
           AvaliacaoFisica avaliacao =  new AvaliacaoFisica
           {
                NumAvaliacao =2,
                DataAvaliacao = new DateTime(2023,02,26),
                Peso=75.2,
                CircCintura = 91,
                CircAbdominal = 93,
                CircQuadril = 96,
                CircPeito = 97,
                CircBracoDireito = 29.5,
                CircBracoEsquerdo =29.5,
                CircCoxadireita = 51,
                CircCoxaEsquerda = 50,
                CircPanturrilhaDireita =20,
                CircPanturrilhaEsquerda=21,
                DCTriceps =11,
                DCEscapular=26,
                DCSupraIliaca=21,
                DCAbdominal =21,
                DCAxilar = 12,
                DCPeitoral =15,
                DCCoxa = 14,
                Paciente  = db.pacientes.Find(1)
           };

           db.AvaliacoesFisicas.Add(avaliacao);
           
           Consulta consulta  = new Consulta
           {
            DataConsulta = new DateTime(2023,02,26),
            Nutricionista = db.Nutricionistas.Find(1),
            PacienteId = avaliacao.PacienteId,
            Avaliacao = avaliacao,
            Observacoes = "Teste de consulta"
           };
            db.Consultas.Add(consulta);

           db.SaveChanges();
        }
       
       
    }
    
}
