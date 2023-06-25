using MeuCondominio.Models.Abstract;
using MeuCondominio.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace MeuCondominio.Models
{
    public class Resident : Person
    {
        [Display(Name = "Número de emergência")]
        public string EmergencyNumber { get; set; }

        [Display(Name = "Código do Ifood")]
        public string IfoodCode { get; set; }

        [Display(Name = "Síndico")]
        [ResidentValidation]
        public Boolean IsManager { get; set; }

        public Resident() { }

        public Resident(
            String emergencyNumber,
            string ifoodCode,
            Boolean isManager,
            string name,
            string email,
            string cpf,
            string phone,
            DateTime bithDate) : base(name, email, cpf, phone, bithDate)
        {
            EmergencyNumber = emergencyNumber;
            IfoodCode = ifoodCode;
            IsManager = isManager;
        }
    }
}
