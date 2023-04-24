using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BL.Dtos.Developers
{
    public class DeveloperAddDto
    {
        public required string Name { get; init; } = string.Empty;
    }
}
