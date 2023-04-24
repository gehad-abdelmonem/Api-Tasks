using IdentityTask.Data.Models;
using IdentityTask.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        public AccountController(UserManager<ApplicationUser> _userManager,IConfiguration _configuration)
        {
            userManager= _userManager;
            configuration= _configuration;
        }
        //user register
        [HttpPost]
        [Route("UserRedister")]
        public async Task<ActionResult> UserRegister(RegisterDto registerDto)
        {
            ApplicationUser User = new ApplicationUser
            {
                UserName=registerDto.userName,
                Email=registerDto.email,
                Address=registerDto.addresss
            };
           var result= await userManager.CreateAsync(User, registerDto.password);
            if (!result.Succeeded) 
            {
                return BadRequest(result.Errors);
            }
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier,User.Id),
                new Claim(ClaimTypes.Name,User.UserName),
                new Claim(ClaimTypes.Role,"User")
            };
            await userManager.AddClaimsAsync(User, claims);
            return Ok("your Account Created Successfully");
            
        }
        //admin register
        [HttpPost]
        [Route("AdminRedister")]
        public async Task<ActionResult> AdminRegister(RegisterDto registerDto)
        {
            ApplicationUser User = new ApplicationUser
            {
                UserName = registerDto.userName,
                Email = registerDto.email,
                Address = registerDto.addresss
            };
            var result = await userManager.CreateAsync(User, registerDto.password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,User.Id),
                new Claim(ClaimTypes.Name,User.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            };
            await userManager.AddClaimsAsync(User, claims);
            return Ok("your Account Created Successfully");

        }
        //login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDto credentials) 
        {
            var User= await userManager.FindByNameAsync(credentials.userName);
            if (User == null)
            {
                return BadRequest();
            }
            var isAuthenticated= await userManager.CheckPasswordAsync(User, credentials.Password);
            if(!isAuthenticated)
            { 
                return Unauthorized();
            }
            var claims= await userManager.GetClaimsAsync(User);
            var secretKeyString = configuration.GetValue<string>("secretKey");
            var secretKeyInBytes=Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey=new SymmetricSecurityKey(secretKeyInBytes);
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var expiryDate=DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiryDate,
                signingCredentials: signinCredentials
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString=tokenHandler.WriteToken(token);
            return Ok( new TokenDto(tokenString));
        }
    }

}
