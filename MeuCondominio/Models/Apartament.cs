namespace MeuCondominio.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public Apartment() { }

        public Apartment(string number, int floor)
        {
            Number = number;
            Floor = floor;
        }
    }

}
