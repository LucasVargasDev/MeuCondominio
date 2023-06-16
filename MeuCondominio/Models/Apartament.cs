using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MeuCondominio.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        [Display(Name = "Número")]
        public string Number { get; set; }
        [Display(Name = "Andar")]
        public int Floor { get; set; }
        public int BuildingId { get; set; }
        [Display(Name = "Prédio")]
        public Building Building { get; set; }

        public Apartment() { }

        public Apartment(string number, int floor)
        {
            Number = number;
            Floor = floor;
        }
    }

}
