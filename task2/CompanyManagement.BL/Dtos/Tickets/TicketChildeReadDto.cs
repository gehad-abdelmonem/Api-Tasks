using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BL.Dtos.Tickets
{
    public class TicketChildeReadDto
    {
        public int id { get; init; }
        public string Description { get; init; } = string.Empty;
        public int DevelopersCount { get; init; }
    }
}
