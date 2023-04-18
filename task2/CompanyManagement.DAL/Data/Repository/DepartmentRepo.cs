using CompanyManagement.DAL.Data.Context;
using CompanyManagement.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL.Data.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private CompanyContext context;
        public DepartmentRepo(CompanyContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            Department department=context.Departments.FirstOrDefault(d=>d.id==id);
            if(department==null)
            {
                return false;
            }
            context.Departments.Remove(department);
            return true;
        }

        public List<Department> GetAll()
        {
           return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            Department department=context.Departments.FirstOrDefault(d=>d.id==id);
            return department;
        }

        public Department?GetByIdWithTicketsAndDevelopers(int id)
        {
            Department? department = context.Departments.Include(d => d.Tickets)
                                                      .ThenInclude(t => t.Developers).FirstOrDefault(d => d.id == id);
            if(department== null)
            {
                return null;
            }
            return department;
        }

        public void SaveChange()
        {
            context.SavingChanges();
        }

        public void Update(Department department)
        {
            
        }
    }
}
