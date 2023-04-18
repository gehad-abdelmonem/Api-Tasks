using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL.Data.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [ForeignKey("dept")]
        public int deptid { get; set; }
        public Department? dept { get; set; }
        public ICollection<Developer>? Developers { get; set; }
    }
}
