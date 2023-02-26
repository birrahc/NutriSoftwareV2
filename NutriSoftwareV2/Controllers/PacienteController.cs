using Microsoft.AspNetCore.Mvc;
using NutriSoftware.Negocio.Domain;
using NutriSoftware.Negocio.Svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriSoftwareV2.Web.Controllers
{
    public class PacienteController : Controller
    {
        public ActionResult Index(int? Id)
        {
            List<Paciente> pacientes = SvcPaciente.ListarPacientes();
            if (Id.HasValue)
            {
                ViewBag.Paciente = SvcPaciente.BuscarPacienteCompleto(Id.Value);
            }
            return View(pacientes);
        }

        [HttpPost]
        public ActionResult PesquisaPaciente(string pesquisaPaciente)
        {
            var pesquisa = SvcPaciente.PesquisarPaciente(pesquisaPaciente);
            return PartialView("PartiaisPaciente/_ListaDePacientes", pesquisa);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("PartiaisPaciente/_FormularioPaciente");
        }

        [HttpPost]
        public ActionResult Create(Paciente paciente)
        {
            try
            {
                if (paciente != null)
                {
                    SvcPaciente.CadastrarPaciente(paciente);
                    ViewBag.Paciente = paciente;
                    var pacientes = SvcPaciente.ListarPacientes();
                    return PartialView("PartiaisPaciente/_Conteudo", pacientes);
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
            return PartialView("PartiaisPaciente/_FormularioPaciente", paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            try
            {
                if (paciente != null)
                {
                    SvcPaciente.AtualizarPaciente(paciente);
                    ViewBag.Paciente = paciente;
                    var pacientes = SvcPaciente.ListarPacientes();
                    return PartialView("PartiaisPaciente/_Conteudo", pacientes);
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
                return PartialView("PartiaisPaciente/_Conteudo", pacientes);
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult CadastrarAnotacoesPaciente(int pacienteId)
        {
            ViewBag.IdPaciente = pacienteId;
            var anotacao = new AnotacoesPaciente { PacienteId = pacienteId, Data = DateTime.Now };
            return PartialView("PartiaisPaciente/_FormularioObservacaoPaciente", anotacao);
        }

        [HttpPost]
        public ActionResult CadastrarAnotacoesPaciente(AnotacoesPaciente anotacao)
        {
            SvcAnotacoes.CadastrarAnotacao(anotacao);
            var anotacoes = SvcAnotacoes.ListarAnotacoesPaciente(anotacao.PacienteId);
            return PartialView("PartiaisPaciente/_ObservacaoPaciente", anotacoes.OrderByDescending(d => d.Id));
        }

        [HttpGet]
        public ActionResult EditarAnotacoesPaciente(int anotacaoId)
        {
            var anotacao = SvcAnotacoes.BuscarAnotacao(anotacaoId);
            return PartialView("PartiaisPaciente/_FormularioObservacaoPaciente", anotacao);
        }

        [HttpPost]
        public ActionResult EditarAnotacoesPaciente(AnotacoesPaciente anotacao)
        {
            SvcAnotacoes.EditarAnotacao(anotacao);
            var anotacoes = SvcAnotacoes.ListarAnotacoesPaciente(anotacao.PacienteId);
            return PartialView("PartiaisPaciente/_ObservacaoPaciente", anotacoes.OrderByDescending(d => d.Id));
        }

        [HttpPost]
        public ActionResult DeletarAnotacao(int anotacaoId)
        {
            var anotacao = SvcAnotacoes.BuscarAnotacao(anotacaoId);
            int pacienteId = anotacao.PacienteId;
            SvcAnotacoes.DeletarAnotacao(anotacao);
            var anotacoes = SvcAnotacoes.ListarAnotacoesPaciente(pacienteId);
            return PartialView("PartiaisPaciente/_ObservacaoPaciente", anotacoes.OrderByDescending(p => p.Id));
        }
    }
}
