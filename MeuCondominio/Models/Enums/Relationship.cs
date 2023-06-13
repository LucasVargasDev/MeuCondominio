using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MeuCondominio.Models.Enums
{
    public enum Relationship
    {
        [Display(Name = "Mãe")]
        Mother,

        [Display(Name = "Pai")]
        Father,

        [Display(Name = "Amigo")]
        Friend,

        [Display(Name = "Primo")]
        Cousin,

        [Display(Name = "Tio")]
        Uncle,

        [Display(Name = "Entregador")]
        Deliveryman,

        [Display(Name = "Serviços")]
        Services,

        [Display(Name = "Outros")]
        Others
    }
}
