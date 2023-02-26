using NutriSoftware.Negocio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriSoftware.Negocio.Domain
{
    public class AlimentoBebida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EN_TipoAlimentoBebida Tipo { get; set; }
        public string DescricaoTipoCaloria { get => Svc.SvcEnum.GetDescription(this.Tipo); }
        public float? Calorias { get; set; }


    }
}