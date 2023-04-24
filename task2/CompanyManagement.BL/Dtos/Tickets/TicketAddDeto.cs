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
        public required string Description { get; set; } = string.Empty;
        public required string Title { get; set; } = string.Empty;
        public required int deptid { get; set; }
        public required ICollection<DeveloperAddDto>? Developers { get; init; }
    }
}
