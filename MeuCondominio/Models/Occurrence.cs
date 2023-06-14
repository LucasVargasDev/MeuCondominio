using MeuCondominio.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MeuCondominio.Models
{
    public class Occurrence
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [EnumDataType(typeof(TypeOccurrence))]
        [Display(Name = "Tipo de Ocorrência")]
        public TypeOccurrence TypeOccurrence { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public int ResidentId { get; set; }
        [Display(Name = "Morador")]
        public Resident Resident { get; set; }

        public Occurrence() { }

        public Occurrence(string name, TypeOccurrence typeOccurrence, DateTime date, string description, Resident resident)
        {
            Name = name;
            TypeOccurrence = typeOccurrence;
            Date = date;
            Description = description;
            Resident = resident;
        }
    }
}
