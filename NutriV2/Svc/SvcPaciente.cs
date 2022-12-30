using Data.NutriDbContext;
using Microsoft.EntityFrameworkCore;
using NutriV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriV2.Svc
{
    public class SvcPaciente
    {
        public static void CadastrarPaciente(Paciente pPaciente)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.pacientes.Add(pPaciente);
                db.SaveChanges();
                db.Dispose();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar paciente", ex);
            }
        }

        public static void AtualizarPaciente(Paciente pPaciente)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.pacientes.Update(pPaciente);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Atualizar paciente", ex);
            }
        }

        public static void DeletarPaciente(int pIdPaciente)
        {
            try
            {
                var paciente = BuscarPacienteCompleto(pIdPaciente);
                NutriDbContext db = new NutriDbContext();
                db.Remove(paciente);
                db.SaveChanges();
                db.Dispose();
            }
            catch(Exception ex) 
            {
                throw new Exception("Erro ao remover paciente", ex);
            }
        }
        public static List<Paciente> ListarPacientes() 
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                List<Paciente> pacientes = db.pacientes.ToList();
                db.Dispose();
                return pacientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar pacientes", ex);
            }
        }
        public static Paciente BuscarPaciente(int pIdPaciente) 
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                Paciente paciente = db.pacientes.Find(pIdPaciente);
                db.Dispose();
                return paciente;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao buscar paciente", ex);
            }
        }
        public static Paciente BuscarPacienteCompleto(int pIdPaciente) 
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                Paciente paciente = db.pacientes.Include(a => a.Avaliacoes)
                                                .Include(p=>p.Pagamentos)
                                                .Include(p=>p.HorariosAgendados)
                                                .Include(p=>p.Consultas)
                                                .Include(p=>p.Anotacoes)
                                                .FirstOrDefault(p => p.Id == pIdPaciente);
                db.Dispose();
                return paciente;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao buscar paciente", ex);
            }
        }

        public static List<Paciente> PesquisarPaciente(string pNome) 
        {
            NutriDbContext db = new NutriDbContext();
            var query = from e in db.pacientes
                        where EF.Functions.Like(e.Nome, $"%{pNome}%")
                        select e;
            return query.ToList();
        }

       
    }
}
