namespace MeuCondominio.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
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
