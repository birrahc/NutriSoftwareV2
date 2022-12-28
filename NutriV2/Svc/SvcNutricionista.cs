using Data.NutriDbContext;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcNutricionista
    {
        public static void CadastrarNutricionista(Nutricionista pNutri) 
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Nutricionistas.Add(pNutri);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar nutricionista ",ex);
            }
        }

        public static void EditarNutricionista(Nutricionista pNutri)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Nutricionistas.Update(pNutri);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar nutricionista ", ex);
            }
        }

        public static void DeletarNutricionista(Nutricionista pNutri)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Nutricionistas.Remove(pNutri);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar nutricionista ", ex);
            }
        }

        public static List<Nutricionista> ListarNutricionistas()
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var nutricionistas = db.Nutricionistas.ToList();
                db.Dispose();
                return nutricionistas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar nutricionista ", ex);
            }
        }

        public static Nutricionista BuscarNutricionista(int pNutriId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var nutricionista = db.Nutricionistas.Find(pNutriId);
                db.Dispose();
                return nutricionista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar nutricionista ", ex);
            }
        }
    }
}
