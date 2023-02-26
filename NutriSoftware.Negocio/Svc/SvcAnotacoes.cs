using NutriSoftware.Negocio.Data.NutriDbContext;
using NutriSoftware.Negocio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriSoftware.Negocio.Svc
{
    public class SvcAnotacoes
    {
        public static void CadastrarAnotacao(AnotacoesPaciente pAnotacao) 
        {
            try 
            {
                NutriDbContext db = new NutriDbContext();
                db.AnotacosPaciente.Add(pAnotacao);
                db.SaveChanges();
                db.Dispose();
            } 
            catch (Exception ex) 
            {
                throw new Exception("Erro ao cadastrar anotação.", ex);
            }
        }

        public static void EditarAnotacao(AnotacoesPaciente pAnotacao)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.AnotacosPaciente.Update(pAnotacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar anotação.", ex);
            }
        }

        public static void DeletarAnotacao(AnotacoesPaciente pAnotacao)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.AnotacosPaciente.Remove(pAnotacao);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover anotação.", ex);
            }
        }

        public static List<AnotacoesPaciente> ListarAnotacoesPaciente(int pPacienteId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var anotacoes = db.AnotacosPaciente.Where(p=>p.PacienteId == pPacienteId).ToList();
                db.Dispose();
                return anotacoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar anotação.", ex);
            }
        }

        public static AnotacoesPaciente BuscarAnotacao(int pAnotacaoId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var anotacao = db.AnotacosPaciente.Find(pAnotacaoId);
                db.Dispose();
                return anotacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar anotação.", ex);
            }
        }
    }
}
