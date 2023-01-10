using Data.NutriDbContext;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcPagamento
    {
        public static void CadastrarPagamento(Pagamento pPagamento)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Pagamentos.Add(pPagamento);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar pagamento ", ex);
            }
        }

        public static void EditarPagamento(Pagamento pPagamento)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Pagamentos.Update(pPagamento);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar pagamento ", ex);
            }
        }
        public static void DeletarPagamento(Pagamento pPagamento)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Pagamentos.Remove(pPagamento);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover pagamento ", ex);
            }
        }
        public static List<Pagamento> ListarPagamentos()
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var pagamentos =db.Pagamentos.ToList();
                db.Dispose();
                return pagamentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar pagamento ", ex);
            }
        }

        public static List<Pagamento> ListarPagamentosPorPaciente(int pPacienteId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var pagamentos = db.Pagamentos.Where(p=>p.PacienteId == pPacienteId).ToList();
                db.Dispose();
                return pagamentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar pagamentos ", ex);
            }
        }

        //public static List<Pagamento> ListarPagamentosPorConsulta(int pConsultaId)
        //{
        //    try
        //    {
        //        NutriDbContext db = new NutriDbContext();
        //        var pagamentos = db.Pagamentos.Where(p => p.ConsultaId == pConsultaId).ToList();
        //        db.Dispose();
        //        return pagamentos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro ao listar pagamentos ", ex);
        //    }
        //}

        public static Pagamento BuscarPagamento(int pPagamentoId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var pagamento = db.Pagamentos.Find(pPagamentoId);
                db.Dispose();
                return pagamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pagamento ", ex);
            }
        }
    }
}
