using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NutriSoftware.Negocio.Domain;
using NutriSoftware.Negocio.Enums;
using NutriSoftware.Negocio.Svc;
using NutriSoftwareV2.Web.Dto;
using NutriSoftwareV2.Web.Svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriSoftwareV2.Web.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public ConsultaController(IMemoryCache memory)
        {
            _memoryCache = memory;
        }
        public ActionResult ConsultasPaciente(int Id)
        {
            ViewBag.Codigo = Guid.NewGuid().ToString();
            ViewBag.Avaliacoes = null;
            return View("ConsultasPaciente", new Consulta {PacienteId=Id, Paciente= SvcPaciente.BuscarPaciente(Id)});
        }

        [HttpPost]
        public ActionResult PrimeiroPassoObservacoes(int PacienteId, string Observacoes, string Codigo)
        {
            var paciente = SvcPaciente.BuscarPaciente(PacienteId);
            var avaliacoesPaciente = SvcAvaliacao.ListarAvaliacoesPorPaciente(PacienteId);
            var ultimaAvaliacao = avaliacoesPaciente.Any() ? avaliacoesPaciente.Select(p => p.NumAvaliacao).Max()+1:1;
            var avalicaoPaciente = new AvaliacaoFisica { PacienteId = PacienteId, Paciente = paciente, NumAvaliacao= ultimaAvaliacao,DataAvaliacao=DateTime.Now};
            ViewBag.AvaliacaoAnterior = avaliacoesPaciente.LastOrDefault();
            ViewBag.CodigoConsulta = Codigo;
            //ViewBag.AvaliacaoSelecionada = avalicaoPaciente;
            var consulta = new Consulta { Observacoes = Observacoes, PacienteId = PacienteId, Paciente = paciente, Avaliacao = avalicaoPaciente };
            SvcMemoryCache.AmarzenarEntidadeUnica<Consulta>(consulta, _memoryCache, Codigo);
            var x = SvcMemoryCache.BuscarEntidade<Consulta>(_memoryCache, Codigo);
            return PartialView("PartiaisConsulta/_ConteudoConsulta", SvcMemoryCache.BuscarEntidade<Consulta>(_memoryCache,Codigo));
        }

        [HttpPost]
        public ActionResult SegundoPassoAvaliacao(AvaliacaoFisica pAvaliacao,string Codigo) 
        {
            var paciente = SvcPaciente.BuscarPaciente(pAvaliacao.PacienteId);
            pAvaliacao.Paciente = paciente;
            pAvaliacao.DataAvaliacao = DateTime.Now;
            SvcMemoryCache.BuscarEntidade<Consulta>(_memoryCache, Codigo).Avaliacao = pAvaliacao;
            var ultimaDietaDoPaciente = SvcDieta.ListarDietasPaciente(pAvaliacao.PacienteId)?.OrderBy(d => d.Data).LastOrDefault();
            if (ultimaDietaDoPaciente != null)
            {
                
                ultimaDietaDoPaciente.CodigoDieta = Codigo;
                ultimaDietaDoPaciente.PlanosAlimentares.ToList().ForEach(p => {

                    var codigoPlano = $"{Codigo}_plano";
                    var codigoObs =$"{Codigo}_obs";
                    p.CodigoDieta = Codigo;
                    p.ObservacaoPlano.CodigoDieta = Codigo;

                    var quantidadeAlimentos = p.QuantidadeAlimentos.Where(h=>h.Hora == p.HoraAlimentos).ToList();

                    if (quantidadeAlimentos.Any())
                    {
                        quantidadeAlimentos.ForEach(c => {
                            c.CodigoDieta = Codigo;
                        });
                        SvcMemoryCache.ArmazenarRangeEntidade<QuantidadeAlimento>(quantidadeAlimentos, _memoryCache, codigoPlano);
                    }

                    if (p.ObservacaoPlano != null)
                    {
                        p.ObservacaoPlano.CodigoDieta = Codigo;
                        SvcMemoryCache.AmarzenarEntidade<ObservacaoPlano>(p.ObservacaoPlano, _memoryCache, codigoObs);
                    }
                   
                });
            }

            SvcMemoryCache.BuscarEntidade<Consulta>(_memoryCache, Codigo).Dieta =ultimaDietaDoPaciente!=null ? ultimaDietaDoPaciente: new Dieta()
            {
                CodigoDieta=Codigo,
                Paciente = paciente,
                PacienteId =pAvaliacao.PacienteId
            };
            ViewBag.CodigoDieta = Codigo;
            return PartialView("PartiaisConsulta/_ConteudoConsulta", SvcMemoryCache.BuscarEntidade<Consulta>(_memoryCache, Codigo));

        } 
        
        [HttpPost]
        public ActionResult TerceiroPassoDieta(int PacienteId, string Codigo) 
        {

            var codigoPlano = $"{Codigo}_plano";
            var codigoObs = $"{Codigo}_obs";
            var alimentos = SvcMemoryCache.ListarEntidade<QuantidadeAlimento>(_memoryCache, codigoPlano);
            var horarios = alimentos.GroupBy(p => p.Hora).ToList();
            var observacoes = SvcMemoryCache.ListarEntidade<ObservacaoPlano>(_memoryCache, codigoObs);
            List<PlanoAlimentar> planos = new List<PlanoAlimentar>();
            horarios.ForEach(p =>
            {
                planos.Add(new PlanoAlimentar
                {
                    CodigoDieta =Codigo,
                    HoraAlimentos = p.Key,
                    QuantidadeAlimentos = alimentos.Where(h => h.Hora == p.Key).ToList(),
                    ObservacaoPlano = observacoes.FirstOrDefault(h => h.HorarioReferencia == p.Key)
                });
            });

            SvcMemoryCache.BuscarEntidade<Consulta>(_memoryCache, Codigo).Dieta = new Dieta()
            {
                CodigoDieta = Codigo,
                Paciente = SvcPaciente.BuscarPaciente(PacienteId),
                PacienteId = PacienteId,
                PlanosAlimentares = planos,
                Data = DateTime.Now
            };
            var avaliacoesPaciente = SvcAvaliacao.ListarAvaliacoesPorPaciente(PacienteId);
            ViewBag.AvaliacaoAnterior = avaliacoesPaciente.LastOrDefault();

            return PartialView("PartiaisConsulta/_ConteudoConsulta", SvcMemoryCache.BuscarEntidade<Consulta>(_memoryCache, Codigo));

        }

        //Montagem da dieta
        [HttpPost]
        public ActionResult AdicionarAlimento(DtoParametrosMontarDieta pMontar)
        {
            if (JaExiste(pMontar.ConvertParamToQuantidadeAlimento(), _memoryCache))
                throw new ApplicationException("Já existe esse alimento para esse horario./");
            var codigoPlano = $"{pMontar.CodigoDieta}_plano";
            SvcMemoryCache.AmarzenarEntidade<QuantidadeAlimento>(pMontar.ConvertParamToQuantidadeAlimento(), _memoryCache, codigoPlano);

            var codigoObs = $"{pMontar.CodigoDieta}_obs";
            var alimentos = SvcMemoryCache.ListarEntidade<QuantidadeAlimento>(_memoryCache, codigoPlano);
            var horarios = alimentos.GroupBy(p => p.Hora).ToList();
            var observacoes = SvcMemoryCache.ListarEntidade<ObservacaoPlano>(_memoryCache, codigoObs);


            List<PlanoAlimentar> planos = new List<PlanoAlimentar>();
            horarios.ForEach(p =>
            {
                planos.Add(new PlanoAlimentar
                {
                    CodigoDieta = pMontar.CodigoDieta,
                    HoraAlimentos = p.Key,
                    QuantidadeAlimentos = alimentos.Where(h => h.Hora == p.Key).ToList(),
                    ObservacaoPlano = observacoes.FirstOrDefault(h => h.HorarioReferencia == p.Key)
                });
            });

            return PartialView("PartiaisConsulta/PartiaisDieta/_ListaAlimentos", planos);
        }

        [HttpPost]
        public ActionResult CadastrarObservacao(ObservacaoPlano pObs)
        {
            if (pObs != null && pObs.HorarioReferencia != null)
            {
                var codigoObs = $"{pObs.CodigoDieta}_obs";
                var Obs = SvcMemoryCache.ListarEntidade<ObservacaoPlano>(_memoryCache, codigoObs);
                if (Obs.Where(h => h.HorarioReferencia == pObs.HorarioReferencia).Any())
                {
                    SvcMemoryCache.ListarEntidade<ObservacaoPlano>(_memoryCache, codigoObs)
                        .FirstOrDefault(p => p.HorarioReferencia == pObs.HorarioReferencia).Anotacoes = pObs.Anotacoes;
                }
                else
                {
                    SvcMemoryCache.AmarzenarEntidade<ObservacaoPlano>(pObs, _memoryCache, codigoObs);
                }
                var codigoPlano = $"{pObs.CodigoDieta}_plano";
                var alimentos = SvcMemoryCache.ListarEntidade<QuantidadeAlimento>(_memoryCache, codigoPlano);
                var observacoes = SvcMemoryCache.ListarEntidade<ObservacaoPlano>(_memoryCache, codigoObs);
                var horarios = alimentos.GroupBy(p => p.Hora).ToList();

                List<PlanoAlimentar> planos = new List<PlanoAlimentar>();
                horarios.ForEach(p =>
                {
                    planos.Add(new PlanoAlimentar
                    {
                        CodigoDieta = pObs.CodigoDieta,
                        HoraAlimentos = p.Key,
                        QuantidadeAlimentos = alimentos.Where(h => h.Hora == p.Key).ToList(),
                        ObservacaoPlano = observacoes.FirstOrDefault(h => h.HorarioReferencia == p.Key)
                    });
                });
                return PartialView("PartiaisConsulta/PartiaisDieta/_ListaAlimentos", planos);
            }
            return PartialView("PartiaisConsulta/PartiaisDieta/_ListaAlimentos");
        }

        [HttpPost]
        public ActionResult RemoverItemDieta(string CodigoDieta, string Hora, int AlimentoId, EN_TipoDietaAlimentos Tipo)
        {
            var codigoPlano = $"{CodigoDieta}_plano";
            var alimentos = SvcMemoryCache.ListarEntidade<QuantidadeAlimento>(_memoryCache, codigoPlano)
                .FirstOrDefault(p => p.CodigoDieta == CodigoDieta && p.Hora == Hora && p.AlimentoId == AlimentoId && p.Tipo == Tipo);

            SvcMemoryCache.RemoverItemEntidade<QuantidadeAlimento>(alimentos, _memoryCache, codigoPlano);
            var codigoObs = $"{CodigoDieta}_obs";
            var ListaAlimentos = SvcMemoryCache.ListarEntidade<QuantidadeAlimento>(_memoryCache, codigoPlano);
            var observacoes = SvcMemoryCache.ListarEntidade<ObservacaoPlano>(_memoryCache, codigoObs);
            var horarios = ListaAlimentos.GroupBy(p => p.Hora).ToList();

            List<PlanoAlimentar> planos = new List<PlanoAlimentar>();
            horarios.ForEach(p =>
            {
                planos.Add(new PlanoAlimentar
                {
                    CodigoDieta = CodigoDieta,
                    HoraAlimentos = p.Key,
                    QuantidadeAlimentos = ListaAlimentos.Where(h => h.Hora == p.Key).ToList(),
                    ObservacaoPlano = observacoes.FirstOrDefault(h => h.HorarioReferencia == p.Key)
                });
            });
            return PartialView("PartiaisConsulta/PartiaisDieta/_ListaAlimentos", planos);
        }

        public static bool JaExiste(QuantidadeAlimento pQuantidadeAlimento, IMemoryCache memoryCache)
        {
            bool existe = SvcMemoryCache.ListarEntidade<QuantidadeAlimento>(memoryCache, pQuantidadeAlimento.CodigoDieta)
                .Any(p => p.CodigoDieta == pQuantidadeAlimento.CodigoDieta &&
                          p.Hora == pQuantidadeAlimento.Hora &&
                          p.AlimentoId == pQuantidadeAlimento.AlimentoId &&
                          p.Tipo == pQuantidadeAlimento.Tipo);

            return existe;
        }
    }
}
