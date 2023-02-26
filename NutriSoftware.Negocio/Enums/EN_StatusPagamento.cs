using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NutriSoftware.Negocio.Enums
{
    public enum EN_StatusPagamento
    {
        APagar=1,

        Pago=2,

        [Description("Pago parcial")]
        PagoParcial =3,

        Gratuito =4,

    }
}
