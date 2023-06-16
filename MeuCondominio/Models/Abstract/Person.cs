using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MeuCondominio.Models.Abstract
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Display(Name = "Telefone")]
        public string Phone { get; set; }
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Person() { }
        public Person(string name, string email, string cpf, string phone, DateTime bithDate)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            Phone = phone;
            BirthDate = bithDate;

        }
    }
}
