using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.NutriDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriV2;

namespace NutriVV2.Web.Controllers
{
    public class Paciente : Controller
    {
        NutriDbContext db = new NutriDbContext();
        public ActionResult Index(int? Id)
        {
            List<NutriV2.Domain.Paciente> pacientes = db.pacientes.ToList();
            db.Dispose();
            if (Id.HasValue)
            {
                ViewBag.Paciente = pacientes.Find(p => p.Id == Id);
            }
            return View(pacientes);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView("AcoesPaciente/_FormularioPaciente");
        }

        [HttpPost]
        public ActionResult Create(NutriV2.Domain.Paciente paciente)
        {
            try
            {
                if (paciente != null)
                {
                    db.pacientes.Add(paciente);
                    db.SaveChanges();
                    ViewBag.Paciente = paciente;
                    var pacientes = db.pacientes.ToList();
                    db.Dispose();
                    return PartialView("AcoesPaciente/_Conteudo", pacientes);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var paciente = db.pacientes.Find(id);
            db.Dispose();
            return PartialView("AcoesPaciente/_FormularioPaciente", paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NutriV2.Domain.Paciente paciente)
        {
            try
            {
                if (paciente != null)
                {
                    db.pacientes.Update(paciente);
                    db.SaveChanges();
                    ViewBag.Paciente = paciente;
                    var pacientes = db.pacientes.ToList();
                    db.Dispose();
                    return PartialView("AcoesPaciente/_Conteudo", pacientes);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                var paciente = db.pacientes.Find(Id);
                db.pacientes.Remove(paciente);
                db.SaveChanges();

                var pacientes = db.pacientes.ToList();
                db.Dispose();

                return PartialView("AcoesPaciente/_Conteudo", pacientes);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult AvaliacoesDoPaciente(int Id)
        {
            NutriV2.Domain.Paciente paciente = db.pacientes.Include(a=>a.Avaliacoes).FirstOrDefault(p=>p.Id == Id);
            db.Dispose();
            return View("AvaliacoesPaciente",paciente);
        }

        [HttpGet]
        public ActionResult CadastraAvaliacaoPaciente(int pacienteId) 
        {
            ViewBag.IdPaciente = pacienteId;
            ViewBag.AvaliacaoAnterior = db.AvaliacoesFisicas.OrderBy(p=>p.DataAvaliacao).LastOrDefault(p=>p.PacienteId == pacienteId);
            return PartialView("AcoesAvaliacao/_FomularioAvaliacao");
        }

        [HttpPost]
        public ActionResult CadastraAvaliacaoPaciente(int IdPaciente, NutriV2.Domain.AvaliacaoFisica avaliacao)
        {
            avaliacao.Paciente = db.pacientes.Find(IdPaciente);
            db.AvaliacoesFisicas.Add(avaliacao);
            db.SaveChanges();
            NutriV2.Domain.Paciente paciente = db.pacientes.Include(a => a.Avaliacoes).FirstOrDefault(p => p.Id == avaliacao.Paciente.Id);
            db.Dispose();
            return PartialView("AcoesAvaliacao/_ConteudoAvaliacao", paciente.Avaliacoes);
        }

        [HttpGet]
        public ActionResult EditarAvaliacaoPaciente(int Id)
        {
           
            NutriV2.Domain.AvaliacaoFisica avaliacao = db.AvaliacoesFisicas.Find(Id);
            //ViewBag.IdPaciente = avaliacao.Paciente.i;
            return PartialView("AcoesAvaliacao/_FomularioAvaliacao",avaliacao);
        }

        [HttpPost]
        public ActionResult EditarAvaliacaoPaciente(int IdPaciente, NutriV2.Domain.AvaliacaoFisica avaliacao)
        {
            //avaliacao.Paciente = db.pacientes.Find(IdPaciente);
            db.AvaliacoesFisicas.Update(avaliacao);
            db.SaveChanges();
            NutriV2.Domain.Paciente paciente = db.pacientes.Include(a => a.Avaliacoes).FirstOrDefault(p => p.Id == avaliacao.PacienteId);
            db.Dispose();
            return PartialView("AcoesAvaliacao/_ConteudoAvaliacao", paciente.Avaliacoes);
        }
    }
}
