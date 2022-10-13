using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BudgetLite.Web.Validation
{
    public class IsBeforeDateAttribute : ValidationAttribute
    {
        private readonly string otherDatePropertyName;

        public IsBeforeDateAttribute(string otherDatePropertyName)
        {
            this.otherDatePropertyName = otherDatePropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Provided Data was null");
            }

            DateTime date = (DateTime)value;
            PropertyInfo? endDateProperty = validationContext.ObjectType.GetProperty(otherDatePropertyName);

            if (endDateProperty == null)
            {
                throw new ArgumentNullException($"Property '{this.otherDatePropertyName}' could not be found.");
            }

            DateTime endDate = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance, null);

            if (date < endDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"Date must come before {this.otherDatePropertyName}");
            }
        }
    }
}
