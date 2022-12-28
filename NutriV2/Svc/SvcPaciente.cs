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

        public static void DeletarPaciente(Paciente pPaciente)
        {
            try
            {
                NutriDbContext db = new NutriDbContext();
                db.Remove(pPaciente);
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
                Paciente paciente = db.pacientes.Include(a => a.Avaliacoes).FirstOrDefault(p => p.Id == pIdPaciente);
                db.Dispose();
                return paciente;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao buscar paciente", ex);
            }
        }

       
    }
}
