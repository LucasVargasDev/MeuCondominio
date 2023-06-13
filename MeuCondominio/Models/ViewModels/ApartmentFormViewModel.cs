namespace MeuCondominio.Models.ViewModels
{
    public class ApartmentFormViewModel
    {
        public Apartment Apartment { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}
