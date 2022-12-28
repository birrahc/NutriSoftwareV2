using Data.NutriDbContext;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcAlimento
    {
        public static void CadastrarAlimento(Alimento pAlimento)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Alimentos.Add(pAlimento);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao cadastrar alimento", ex);
            }
        }
        public static void EditarAlimento(Alimento pAlimento)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Alimentos.Update(pAlimento);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar alimento", ex);
            }
        }
        public static void DeletarAlimento(Alimento pAlimento)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Alimentos.Remove(pAlimento);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover alimento", ex);
            }
        }
        public static List<Alimento> ListarAlimentos()
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var alimentos = db.Alimentos.ToList();
                db.Dispose();
                return alimentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar alimentos", ex);
            }
        }
        public static Alimento BuscarAlimento(int pAlimentoId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var alimento = db.Alimentos.Find(pAlimentoId);
                db.Dispose();
                return alimento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar alimento", ex);
            }
        }
    }
}
