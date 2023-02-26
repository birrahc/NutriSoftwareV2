using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutriSoftware.Negocio.Domain;
using NutriSoftware.Negocio.Enums;
using NutriSoftware.Negocio.Svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriSoftwareV2.UnitTest
{
    [TestClass]
    public class QuantidadeAlimentoPlanoAlimentarTest
    {
        [TestMethod]
        public void testInserirPlanoAlimentar()
        {
            //var teste = SvcPlanoAlimentar.ListarPlanosAlimentaresPaciente(2);

            string codigo = Guid.NewGuid().ToString();
            List<QuantidadeAlimento> alimentos = new List<QuantidadeAlimento>()
            {
                new QuantidadeAlimento{Hora="10:00", CodigoDieta = codigo, AlimentoId = 45, TipoMedidaId = 1 , Quantidade =2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="10:00", CodigoDieta = codigo, AlimentoId = 46, TipoMedidaId = 3, Quantidade = 2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="10:00", CodigoDieta = codigo, AlimentoId = 50, TipoMedidaId = 2, Quantidade = 3,Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="10:00",CodigoDieta = codigo, AlimentoId = 51, TipoMedidaId = 1, Quantidade = 4, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },
                new QuantidadeAlimento{Hora="10:00",CodigoDieta = codigo, AlimentoId = 56, TipoMedidaId = 4, Quantidade = 5, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },
                new QuantidadeAlimento{Hora="10:00",CodigoDieta = codigo, AlimentoId = 47, TipoMedidaId = 2, Quantidade = 6, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },

                new QuantidadeAlimento{Hora="10:00",CodigoDieta = codigo, AlimentoId = 76, TipoMedidaId = 4, Quantidade = 5, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Intervalo },
                new QuantidadeAlimento{Hora="10:00",CodigoDieta = codigo, AlimentoId = 48, TipoMedidaId = 2, Quantidade = 6, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Intervalo },

                new QuantidadeAlimento{Hora="12:00", CodigoDieta = codigo, AlimentoId = 55, TipoMedidaId = 1 , Quantidade =2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="12:00", CodigoDieta = codigo, AlimentoId = 57, TipoMedidaId = 3, Quantidade = 2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="12:00", CodigoDieta = codigo, AlimentoId = 66, TipoMedidaId = 2, Quantidade = 3,Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="12:00",CodigoDieta = codigo, AlimentoId = 62, TipoMedidaId = 1, Quantidade = 4, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento },
                new QuantidadeAlimento{Hora="12:00",CodigoDieta = codigo, AlimentoId = 61, TipoMedidaId = 4, Quantidade = 5, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },
                new QuantidadeAlimento{Hora="12:00",CodigoDieta = codigo, AlimentoId = 60, TipoMedidaId = 2, Quantidade = 6, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },

                new QuantidadeAlimento{Hora="12:00",CodigoDieta = codigo, AlimentoId = 70, TipoMedidaId = 4, Quantidade = 5, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Intervalo },
                new QuantidadeAlimento{Hora="12:00",CodigoDieta = codigo, AlimentoId = 52, TipoMedidaId = 2, Quantidade = 6, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Intervalo },

                new QuantidadeAlimento{Hora="16:00", CodigoDieta = codigo, AlimentoId = 69, TipoMedidaId = 1 , Quantidade =2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="16:00", CodigoDieta = codigo, AlimentoId = 73, TipoMedidaId = 3, Quantidade = 2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="16:00", CodigoDieta = codigo, AlimentoId = 49, TipoMedidaId = 2, Quantidade = 3,Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="16:00",CodigoDieta = codigo, AlimentoId = 50, TipoMedidaId = 1, Quantidade = 4, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },
                new QuantidadeAlimento{Hora="16:00",CodigoDieta = codigo, AlimentoId = 58, TipoMedidaId = 4, Quantidade = 5, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },
                new QuantidadeAlimento{Hora="16:00",CodigoDieta = codigo, AlimentoId = 53, TipoMedidaId = 2, Quantidade = 6, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },


                new QuantidadeAlimento{Hora="16:00", CodigoDieta = codigo, AlimentoId = 70, TipoMedidaId = 1 , Quantidade =2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Intervalo},
                new QuantidadeAlimento{Hora="16:00", CodigoDieta = codigo, AlimentoId = 50, TipoMedidaId = 3, Quantidade = 2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Intervalo},


                new QuantidadeAlimento{Hora="20:00", CodigoDieta = codigo, AlimentoId = 65, TipoMedidaId = 2, Quantidade = 3,Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento},
                new QuantidadeAlimento{Hora="20:00",CodigoDieta = codigo, AlimentoId = 68, TipoMedidaId = 1, Quantidade = 4, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento },
                new QuantidadeAlimento{Hora="20:00",CodigoDieta = codigo, AlimentoId = 72, TipoMedidaId = 4, Quantidade = 5, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Alimento },
                new QuantidadeAlimento{Hora="20:00",CodigoDieta = codigo, AlimentoId = 76, TipoMedidaId = 2, Quantidade = 6, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Substituicao },

                new QuantidadeAlimento{Hora="20:00", CodigoDieta = codigo, AlimentoId = 45, TipoMedidaId = 3, Quantidade = 2, Tipo = NutriSoftware.Negocio.Enums.EN_TipoDietaAlimentos.Intervalo},

            };



            List<ObservacaoPlano> observacaos = new List<ObservacaoPlano>()
            {
                new ObservacaoPlano{ CodigoDieta = codigo, HorarioReferencia="10:00", Anotacoes="dieta das 10"},
                new ObservacaoPlano{ CodigoDieta = codigo, HorarioReferencia="12:00", Anotacoes="dieta das 12"}
            };

            SvcDieta.SalvarDieta(codigo, 2, alimentos, observacaos);



        }

        [TestMethod]
        public void TestBuscarQuantidadeAlimento()
        {
            var xxx = SvcQuantidadeAlimento.BuscarQuantidadeAlimento("32ee81e2-2da7-46b9-b6a6-46ebe2692a64", "08:00", 52, EN_TipoDietaAlimentos.Substituicao);
        }
    }
}
