using CompanyManagement.DAL.Data.Context;
using CompanyManagement.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL.Data.Repository
{
    public class TicketRepo : ITicketRepo
    {
        CompanyContext context;
        public TicketRepo(CompanyContext _context)
        {
            context= _context;
        }
        public void Add(Ticket ticket)
        {
            context.Tickets.Add(ticket);
          
        }

        public bool Delete(int id)
        {
            Ticket? ticket = context.Tickets.FirstOrDefault(t => t.id == id);
            if (ticket == null) return false;
            context.Tickets.Remove(ticket);
            return true;
            
        }

        public void Edit(Ticket ticket)
        {
           
        }

        public List<Ticket> GetAll()
        {
            return context.Tickets.ToList();
        }

        public Ticket? GetById(int id)
        {

            return context.Set<Ticket>().Find(id);
        }

        public void saveChange()
        {
            context.SaveChanges();
        }
    }
}
