using Data.NutriDbContext;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcAgenda
    {
        public static void AgendarConsulta(Agenda pAgenda)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Agenda.Add(pAgenda);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao agendar consulta", ex);
            }
        }

        public static void EditarConsulta(Agenda pAgenda)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Agenda.Update(pAgenda);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar agendamento", ex);
            }
        }

        public static void DeletarConsulta(Agenda pAgenda)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Agenda.Remove(pAgenda);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover agendamento", ex);
            }
        }

        public static List<Agenda>ListarAgendamentos()
        {
            NutriDbContext db = new NutriDbContext();
            var agendamentos = db.Agenda.ToList();
            db.Dispose();
            return agendamentos;
        }

        public static List<Agenda> ListarAgendamentosPorPaciente(int pIdPaciente)
        {
            NutriDbContext db = new NutriDbContext();
            var agendamentos = db.Agenda.Where(p=>p.PacienteId == pIdPaciente).ToList();
            db.Dispose();
            return agendamentos;
        }

        public static Agenda BuscarAgendamento(int pIdAgenda)
        {
            NutriDbContext db = new NutriDbContext();
            var agendamento = db.Agenda.Find(pIdAgenda);
            db.Dispose();
            return agendamento;
        }
    }
}
