using System.ComponentModel;

namespace NutriSoftware.Negocio.Enums
{
    public enum EN_TipoConsulta
    {
        Consulta = 1,
        Retorno = 2,
        [Description("Consulta (pacote)")]
        ConsultaPacote=3,
        [Description("Retorno (pacote)")]
        RetornoPacote =4,
        Desafio =5
    }
}