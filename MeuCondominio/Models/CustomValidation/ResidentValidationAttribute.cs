using System.ComponentModel.DataAnnotations;

namespace MeuCondominio.Models.CustomValidation
{
    public class ResidentValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var resident = (Resident)validationContext.ObjectInstance;

            if(resident.IsManager && !isLegalAge(resident.BirthDate))
            {
                return new ValidationResult("O morador deve ter pelo menos 18 anos para ser síndico.");
            }

            return ValidationResult.Success;
        }

        private Boolean isLegalAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            return age >= 18;
        }
    }
}
