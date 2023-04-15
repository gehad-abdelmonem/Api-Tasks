using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using task1.validation;

namespace task1.models
{
    public class Car
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        [validationDatePast(ErrorMessage ="production date must be in past")]
        public DateTime productionDate { get; set; }
        public string type { get; set; } = string.Empty;
    }
}
