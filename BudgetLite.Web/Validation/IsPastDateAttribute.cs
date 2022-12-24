using System.ComponentModel.DataAnnotations;

namespace BudgetLite.Web.Validation
{
    public class IsPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime datetime = (DateTime)value;

            if (datetime <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"Date must be in the past.");
            }
        }
    }
}
