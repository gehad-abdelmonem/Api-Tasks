
using IdentityTask.Data.Context;
using IdentityTask.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace IdentityTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //add database services
            builder.Services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            //add identity service
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
                    .AddEntityFrameworkStores<DBContext>();

            //add authentication service
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "cool";
                options.DefaultChallengeScheme = "cool";
            }
            )
            .AddJwtBearer("cool", options =>
                {

                    var secretKeyString = builder.Configuration.GetValue<string>("secretKey");
                    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                    var secretKey = new SymmetricSecurityKey(secretKeyInBytes);
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = secretKey,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            //add authorization services
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy
                .RequireClaim(ClaimTypes.Role, "Admin")
                .RequireClaim(ClaimTypes.NameIdentifier)
                );
                options.AddPolicy("AdminOrUser", policy => policy
                .RequireClaim(ClaimTypes.Role, "Admin", "User")
                .RequireClaim(ClaimTypes.NameIdentifier)
                );
            });

            /////////////////////////////////////
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}