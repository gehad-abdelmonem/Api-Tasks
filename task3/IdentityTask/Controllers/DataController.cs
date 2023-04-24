using IdentityTask.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        public DataController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        { 
          var user= await userManager.GetUserAsync(User);
            return Ok(new
            {
                userName = user.UserName,
                email = user.Email,
                address = user.Address
            });
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        [Route("admin")]
        public ActionResult GetInfoForManager()
        {
            return Ok("hello admin");
        }
        [HttpGet]
        [Authorize(Policy = "AdminOrUser")]
        [Route("adminOrUser")]
        public ActionResult GetInfoForUser()
        {
            return Ok("hello admin or user");
        }
    }
}
