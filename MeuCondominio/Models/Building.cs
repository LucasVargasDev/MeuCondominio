using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MeuCondominio.Models
{
    public class Building
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Display(Name = "Bairro")]
        public string District { get; set; }
        [Display(Name = "Rua")]
        public string Street { get; set; }
        [Display(Name = "CEP")]
        public string ZipCode { get; set; }
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        public List<Apartment> Apartments { get; set; }

        public Building()
        {
            Apartments = new List<Apartment>();
        }

        public Building(string name, string city, string district, string street, string zipCode, string phoneNumber)
        {
            Name = name;
            City = city;
            District = district;
            Street = street;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
        }
    }

}
