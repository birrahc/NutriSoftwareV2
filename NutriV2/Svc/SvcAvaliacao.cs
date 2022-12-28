using Data.NutriDbContext;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcAvaliacao
    {
        public static void CadastrarAvaliacao(AvaliacaoFisica pAvaliacao)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.AvaliacoesFisicas.Add(pAvaliacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao cadastrar avaliação", ex);
            }
        }
        public static void EditarAvaliacao(AvaliacaoFisica pAvaliacao)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.AvaliacoesFisicas.Update(pAvaliacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar avaliação", ex);
            }
        }
        public static void DeletarAvaliacao(int pIdAvaliacao) 
        {
            try
            {
                var avaliacao = BuscarAvalicao(pIdAvaliacao);
                NutriDbContext db = new NutriDbContext();
                db.AvaliacoesFisicas.Remove(avaliacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar avaliação", ex);
            }
        }
        public static List<AvaliacaoFisica> ListarAvaliacoesPorPaciente(int pPacienteId) 
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var avaliacoes = db.AvaliacoesFisicas.Where(p => p.PacienteId == pPacienteId).ToList();
                db.Dispose();
                return avaliacoes;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao listar avalições", ex);
            }
        }

        public static AvaliacaoFisica BuscarAvalicao(int pIdAvaliacao) 
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var avaliacao = db.AvaliacoesFisicas.Find(pIdAvaliacao);
                db.Dispose();
                return avaliacao;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao buscar avaliação", ex);
            }
        }
        /*
            avaliacao.Paciente = db.pacientes.Find(IdPaciente);
            db.AvaliacoesFisicas.Add(avaliacao);
            db.SaveChanges();
         */
    }
}
