using CompanyManagement.BL.Dtos.Tickets;
using CompanyManagement.DAL.Data.Models;
using CompanyManagement.DAL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BL.Managers.Tickets
{
   
    public class TicketManager : ITicketsManager
    {
        private ITicketRepo ticketRepo;
        public TicketManager(ITicketRepo _ticketRepo)
        {
            ticketRepo = _ticketRepo;
        }

        public void Add(TicketAddDeto ticket)
        {
            Ticket TicketToDb = new Ticket
            {
                Description = ticket.Description,
                Title = ticket.Title,
                deptid=ticket.deptid,
                Developers = ticket.Developers.Select(d => new Developer
                {
                    Name = d.Name

                }).ToList()
            };
            ticketRepo.Add(TicketToDb);
            ticketRepo.saveChange();
        }

        public bool Delete(int id)
        {
            bool result=ticketRepo.Delete(id);
            if(result==false)
            {
                return false;
            }
            ticketRepo.saveChange();
            return true;
        }

        public List<TicketsReadDtos>? GetAll()
        {
          List<Ticket> ticketsFromDb=ticketRepo.GetAll();
            if(ticketsFromDb==null) 
            {
                return null;
            }
            return ticketsFromDb.Select(t => new TicketsReadDtos
            {
                id = t.id,
                Description = t.Description,
                Title = t.Title,
            }).ToList();

        }

        public TicketsReadDtos? GetById(int id)
        {
           Ticket? ticketFromDb=ticketRepo.GetById(id);
            if(ticketFromDb is null)
            {
                return null;
            }
            return new TicketsReadDtos
            {
                id = ticketFromDb.id,
                Description = ticketFromDb.Description,
                Title = ticketFromDb.Title,
            };
        }
    }
}
