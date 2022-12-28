using Data.NutriDbContext;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcFormacao
    {
        public static void CadastrarFormacao(Formacao pFormacao) 
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Formacoes.Add(pFormacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar formação ", ex);
            }
        }

        public static void EditarFormacao(Formacao pFormacao)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Formacoes.Update(pFormacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar formação ", ex);
            }
        }

        public static void DeletarFormacao(Formacao pFormacao)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Formacoes.Remove(pFormacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover formação ", ex);
            }
        }

        public static List<Formacao> ListarFormacoes()
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var formacoes = db.Formacoes.ToList();
                db.Dispose();
                return formacoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar formação ", ex);
            }
        }

        public static List<Formacao> ListarFormacoesPorNutricionista(int pNutricionistaId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var formacoes = db.Formacoes.Where(p=>p.NutricionistaId == pNutricionistaId).ToList();
                db.Dispose();
                return formacoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar formação ", ex);
            }
        }

        public static Formacao BuscarFormacao(int pFormacaoId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var formacoe = db.Formacoes.Find(pFormacaoId);
                db.Dispose();
                return formacoe;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar formação ", ex);
            }
        }

    }
}
