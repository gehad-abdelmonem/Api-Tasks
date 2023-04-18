using CompanyManagement.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL.Data.Context
{
    public class CompanyContext:DbContext
    {
        public DbSet<Department> Departments =>Set<Department>();
        public DbSet<Ticket> Tickets=>Set<Ticket>();
        public DbSet<Developer> Developers =>Set<Developer>();
        public CompanyContext(DbContextOptions options) : base(options) { }

        internal void SavingChanges()
        {
            throw new NotImplementedException();
        }
    }
}
