using MeuCondominio.Models.Enums;

namespace MeuCondominio.Models.ViewModels
{
    public class OccurrenceFormViewModel
    {
        public Occurrence Occurrence { get; set; }
        public ICollection<TypeOccurrence> TypeOccurrences { get; set; }
        public ICollection<Resident> Residents { get; set; }
    }
}
