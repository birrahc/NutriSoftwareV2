using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NutriV2.Enums
{
    public enum EN_TipoDeContatoTelefone
    {

        [Display(Name = "Somente ligações")]
        [Description("Somente ligações")]
        SomenteLigacoes =1,


        [Display(Name = "Somente WhatsApp")]
        [Description("Somente WhatsApp")]
        SomenteWhatsApp =2,


        [Display(Name = "Ligações e WhatsApp")]
        [Description("Ligações e WhatsApp")]
        LigacoesEWhatsApp =3
    }
}