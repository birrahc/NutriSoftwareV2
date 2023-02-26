using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NutriSoftware.Negocio.Domain;
using NutriSoftware.Negocio.Svc;
using NutriSoftwareV2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NutriSoftwareV2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public ActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [HttpPost]
        public JsonResult AutoComplete(string busca)
        {

            var lista = SvcAlimentoBebida.ListarAlimentos();
            var alimentos = (from alimento in lista
                             where alimento.Nome.StartsWith(busca, StringComparison.OrdinalIgnoreCase)
                             select new
                             {
                                 label = alimento.Nome,
                                 val = alimento.Id
                             }).ToList();
            
            return Json(alimentos.Distinct());
        }
        
        [HttpPost]
        public JsonResult AutoCompleteTipoMedidas(string busca)
        {

            var lista = SvcTipoMedida.ListarTiposDeMedida();
            var medidas = (from medida in lista
                             where medida.Descricao.StartsWith(busca, StringComparison.OrdinalIgnoreCase)
                             select new
                             {
                                 label = medida.Descricao,
                                 val = medida.Id
                             }).ToList();
            
            return Json(medidas.Distinct());
        }

        [HttpPost]
        public ActionResult Index(string CustomerName, string CustomerId)
        {
            ViewBag.Message = "CustomerName: " + CustomerName + " CustomerId: " + CustomerId;
            return View();
        }
    }
}
