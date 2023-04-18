using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BL.Dtos.Tickets
{
    public class TicketsReadDtos
    {
        public int id { get; init; }
        public string Description { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
    }
}
