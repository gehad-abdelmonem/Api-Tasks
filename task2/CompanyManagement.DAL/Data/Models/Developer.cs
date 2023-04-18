using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL.Data.Models
{
    public class Developer
    {
        public int id { get; set; }
        public string Name { get; set; }=string.Empty;
        public ICollection<Ticket> ?Tickets { get; set; }
    }
}
