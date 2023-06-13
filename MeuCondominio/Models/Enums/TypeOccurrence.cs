using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MeuCondominio.Models.Enums
{
    public enum TypeOccurrence
    {
        [Display(Name = "Multa")]
        Fine,

        [Display(Name = "Notificação")]
        Notification,

        [Display(Name = "Manutenção")]
        Maintenance
    }
}
