using CompanyManagement.BL.Dtos.Department;
using CompanyManagement.BL.Dtos.Tickets;
using CompanyManagement.DAL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.DAL.Data.Models;

namespace CompanyManagement.BL.Managers.Departments
{
    public class DepartmentManager : IDepartmentManager
    {
        IDepartmentRepo departmentrepo;
        public DepartmentManager(IDepartmentRepo _departmentrepo)
        {
            departmentrepo= _departmentrepo;
        }
        public DepartmentDetailsDto? GetByIdWithDetails(int id)
        {
            Department? DepartmentFromDb =departmentrepo.GetByIdWithTicketsAndDevelopers(id);
            if(DepartmentFromDb==null)
            {
                return null;
            }
            return new DepartmentDetailsDto
            {
                id = id,
                Name = DepartmentFromDb.Name,
                Tickets = DepartmentFromDb.Tickets.Select(ticketDb => new TicketChildeReadDto
                {
                    id = ticketDb.id,
                    Description = ticketDb.Description,
                    DevelopersCount = ticketDb.Developers.Count
                }).ToList()
            };
        }
    }
}
