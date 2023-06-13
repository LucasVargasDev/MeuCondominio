using MeuCondominio.Models.Abstract;

namespace MeuCondominio.Models
{
    public class Resident : Person
    {
        public string EmergencyNumber { get; set; }
        public string IfoodCode { get; set; }
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
