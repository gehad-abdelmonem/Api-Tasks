using CompanyManagement.BL.Dtos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BL.Managers.Tickets
{
    public interface ITicketsManager
    {
        List<TicketsReadDtos> GetAll();
        TicketsReadDtos GetById(int id);
        void Add(TicketAddDeto ticket);
        bool Delete(int id);
    }
}
