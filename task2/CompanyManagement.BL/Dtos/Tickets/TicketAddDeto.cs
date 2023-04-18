using CompanyManagement.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.BL.Dtos.Developers;

namespace CompanyManagement.BL.Dtos.Tickets
{
    public class TicketAddDeto
    {
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int deptid { get; set; }
        public ICollection<DeveloperAddDto>? Developers { get; init; }
    }
}
