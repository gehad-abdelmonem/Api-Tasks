using IdentityTask.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityTask.Data.Context
{
    public class DBContext:IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions options):base(options)
        {
                
        }
    }
   
}
