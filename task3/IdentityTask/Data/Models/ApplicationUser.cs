using Microsoft.AspNetCore.Identity;

namespace IdentityTask.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; } = string.Empty;
    }
}
