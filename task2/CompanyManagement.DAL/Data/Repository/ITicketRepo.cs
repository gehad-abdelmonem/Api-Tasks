using CompanyManagement.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL.Data.Repository
{
    public interface ITicketRepo
    {
        List<Ticket> GetAll();
        Ticket? GetById(int id);
        void Add(Ticket ticket);
        bool Delete(int id);
        void Edit(Ticket ticket);
        void saveChange();


    }
}
