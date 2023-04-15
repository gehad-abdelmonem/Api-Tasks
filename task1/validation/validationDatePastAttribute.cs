using System.ComponentModel.DataAnnotations;

namespace task1.validation
{
    public class validationDatePastAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var date = value as DateTime?;
            return date != null && date < DateTime.Now;

        }
    }
}
