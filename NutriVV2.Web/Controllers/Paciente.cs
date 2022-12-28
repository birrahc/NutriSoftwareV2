﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.NutriDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriV2;
using NutriV2.Svc;

namespace NutriVV2.Web.Controllers
{
    public class Paciente : Controller
    {
        public ActionResult Index(int? Id)
        {
            List<NutriV2.Domain.Paciente> pacientes = SvcPaciente.ListarPacientes();
            if (Id.HasValue)
            {
                ViewBag.Paciente = SvcPaciente.BuscarPacienteCompleto(Id.Value);
            }
            return View(pacientes);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
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
                    SvcPaciente.CadastrarPaciente(paciente);
                    ViewBag.Paciente = paciente;
                    var pacientes = SvcPaciente.ListarPacientes();
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
            var paciente = SvcPaciente.BuscarPacienteCompleto(id);
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
                    SvcPaciente.AtualizarPaciente(paciente);
                    ViewBag.Paciente = paciente;
                    var pacientes = SvcPaciente.ListarPacientes();
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
                SvcPaciente.DeletarPaciente(Id);
                var pacientes = SvcPaciente.ListarPacientes();
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
            NutriV2.Domain.Paciente paciente = SvcPaciente.BuscarPacienteCompleto(Id);
            return View("AvaliacoesPaciente",paciente);
        }

        [HttpGet]
        public ActionResult CadastraAvaliacaoPaciente(int pacienteId) 
        {
            ViewBag.IdPaciente = pacienteId;
            ViewBag.AvaliacaoAnterior = SvcAvaliacao.ListarAvaliacoesPorPaciente(pacienteId).OrderBy(p=>p.DataAvaliacao).LastOrDefault();
            return PartialView("AcoesAvaliacao/_FomularioAvaliacao");
        }

        [HttpPost]
        public ActionResult CadastraAvaliacaoPaciente(int IdPaciente, NutriV2.Domain.AvaliacaoFisica avaliacao)
        {
            if(avaliacao !=null && avaliacao.PacienteId > 0) 
            {
                SvcAvaliacao.CadastrarAvaliacao(avaliacao);
                NutriV2.Domain.Paciente paciente = SvcPaciente.BuscarPacienteCompleto(avaliacao.PacienteId);
                return PartialView("AcoesAvaliacao/_ConteudoAvaliacao", paciente.Avaliacoes);
            }
           
            return PartialView("AcoesAvaliacao/_ConteudoAvaliacao");
        }

        [HttpGet]
        public ActionResult EditarAvaliacaoPaciente(int Id)
        {
           
            NutriV2.Domain.AvaliacaoFisica avaliacao = SvcAvaliacao.BuscarAvalicao(Id);
            return PartialView("AcoesAvaliacao/_FomularioAvaliacao",avaliacao);
        }

        [HttpPost]
        public ActionResult EditarAvaliacaoPaciente(int IdPaciente, NutriV2.Domain.AvaliacaoFisica avaliacao)
        {
            if (avaliacao != null && avaliacao.PacienteId > 0) 
            {
                SvcAvaliacao.EditarAvaliacao(avaliacao);
                NutriV2.Domain.Paciente paciente = SvcPaciente.BuscarPacienteCompleto(avaliacao.PacienteId);
                return PartialView("AcoesAvaliacao/_ConteudoAvaliacao", paciente.Avaliacoes);
            }
            
            return PartialView("AcoesAvaliacao/_ConteudoAvaliacao");
        }
    }
}
