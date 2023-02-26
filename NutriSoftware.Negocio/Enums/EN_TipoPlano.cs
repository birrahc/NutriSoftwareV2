using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NutriSoftware.Negocio.Enums
{
    public enum EN_TipoPlano
    {
        [Description("Consulta normal")]
        ConsultaNormal =1,

        [Description("pacote")]
        Pacote = 2,

        [Description("Gratuito")]
        Gratuito = 3,

        [Description("Convênio")]
        Convenio = 4,
    }
}
