using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriSoftware.Negocio.Svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriSoftware.Negocio;
using NutriSoftware.Negocio.Domain;
using NutriSoftware.Negocio.Dto;

namespace NutriSoftwareV2.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
        // GET: AvaliacaoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AvaliacaoController/Details/5
        [HttpGet]
        public ActionResult AvaliacoesDoPaciente(int Id)
        {
            List<AvaliacaoFisica> pAvaliacoes  = SvcAvaliacao.ListarAvaliacoesPorPaciente(Id);
            return View("AvaliacoesPaciente", pAvaliacoes);
        }

        [HttpGet]
        public ActionResult ListarEntreAvaliacoes(ParametrosPesquisaEntreAvaliacoes pPesquisa)
        {
            if (!pPesquisa.PrimeiroParamPesquisa.HasValue && !pPesquisa.SegundoParamPesquisa.HasValue)
                return PartialView("PartiaisAvaliacao/_ConteudoAvaliacao", SvcAvaliacao.ListarAvaliacoesPorPaciente(pPesquisa.PacienteId));
            var entreAvaliacoes = SvcAvaliacao.ListarEntreAvaliacoesPaciente(pPesquisa);
            return PartialView("PartiaisAvaliacao/_ConteudoAvaliacao", entreAvaliacoes);
        }

        [HttpGet]
        public ActionResult CadastraAvaliacaoPaciente(int pacienteId)
        {
            ViewBag.IdPaciente = pacienteId;
            ViewBag.AvaliacaoAnterior = SvcAvaliacao.ListarAvaliacoesPorPaciente(pacienteId).OrderBy(p => p.DataAvaliacao).LastOrDefault();
            return PartialView("PartiaisAvaliacao/_FomularioAvaliacao");
        }

        [HttpPost]
        public ActionResult CadastraAvaliacaoPaciente(int IdPaciente, AvaliacaoFisica avaliacao)
        {
            if (avaliacao != null && avaliacao.PacienteId > 0)
            {
                SvcAvaliacao.CadastrarAvaliacao(avaliacao);
                List<AvaliacaoFisica> AvaliacoesPaciente = SvcAvaliacao.ListarAvaliacoesPorPaciente(avaliacao.PacienteId);
                return PartialView("PartiaisAvaliacao/_ConteudoAvaliacao", AvaliacoesPaciente);
            }

            return PartialView("PartiaisAvaliacao/_ConteudoAvaliacao");
        }

        [HttpGet]
        public ActionResult EditarAvaliacaoPaciente(int Id)
        {

            AvaliacaoFisica avaliacao = SvcAvaliacao.BuscarAvalicao(Id);
            return PartialView("PartiaisAvaliacao/_FomularioAvaliacao", avaliacao);
        }

        [HttpPost]
        public ActionResult EditarAvaliacaoPaciente(AvaliacaoFisica avaliacao)
        {
            if (avaliacao != null && avaliacao.PacienteId > 0)
            {
                SvcAvaliacao.EditarAvaliacao(avaliacao);
                List<AvaliacaoFisica> Avaliacoes = SvcAvaliacao.ListarAvaliacoesPorPaciente(avaliacao.PacienteId);
                return PartialView("PartiaisAvaliacao/_ConteudoAvaliacao", Avaliacoes);
            }

            return PartialView("PartiaisAvaliacao/_ConteudoAvaliacao");
        }

        [HttpPost]
        public ActionResult DeletarAvaliacao(int avaliacaoId, int pacienteId)
        {
            SvcAvaliacao.DeletarAvaliacao(avaliacaoId);
            return PartialView("PartiaisAvaliacao/_ConteudoAvaliacao", SvcAvaliacao.ListarAvaliacoesPorPaciente(pacienteId));
        }




        // GET: AvaliacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AvaliacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvaliacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AvaliacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvaliacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
