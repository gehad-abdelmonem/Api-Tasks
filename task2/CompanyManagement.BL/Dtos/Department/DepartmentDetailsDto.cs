using CompanyManagement.BL.Dtos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BL.Dtos.Department
{
    public class DepartmentDetailsDto
    {
        public int id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<TicketChildeReadDto> Tickets { get; init; } = new();
    }
}
