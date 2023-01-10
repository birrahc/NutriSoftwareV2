using Data.NutriDbContext;
using Microsoft.EntityFrameworkCore;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcConsulta
    {
        public static void CadastrarConsulta(Consulta pConsulta) 
        {
            try 
            {
                NutriDbContext db = new NutriDbContext();
                db.Consultas.Add(pConsulta);
                db.Dispose();
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao Cadastrar Consulta", ex);
            }
        }

        public static void EditarConsulta(Consulta pConsulta)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Consultas.Update(pConsulta);
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Consulta", ex);
            }
        }

        public static void DeletarConsulta(Consulta pConsulta)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Consultas.Remove(pConsulta);
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover Consulta", ex);
            }
        }

        public static List<Consulta> ListarConsultas()
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var consultas = db.Consultas.ToList();
                db.Dispose();
                return consultas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Consulta", ex);
            }
        }

        public static List<Consulta> ListarConsultasPorPaciente(int pPacienteId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var consultas = db.Consultas.Include(n=>n.Nutricionista)
                                            .Include(p=>p.Paciente)
                                            .Include(pg=>pg.Pagamento)
                                            .Include(a=>a.Avaliacao)
                                            .Where(p=>p.PacienteId==pPacienteId).ToList();
                db.Dispose();
                return consultas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Consulta", ex);
            }
        }

        public static Consulta BuscarConsulta(int pConsultaId)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                var consulta = db.Consultas.Find(pConsultaId);
                db.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Consulta", ex);
            }
        }
    }
}
