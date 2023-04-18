using CompanyManagement.BL.Managers.Departments;
using CompanyManagement.BL.Managers.Tickets;
using CompanyManagement.DAL;
using CompanyManagement.DAL.Data.Context;
using CompanyManagement.DAL.Data.Repository;
using Microsoft.EntityFrameworkCore;


namespace CompanyManagment_APIS
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
            builder.Services.AddDbContext<CompanyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            //repo service
            builder.Services.AddScoped<ITicketRepo, TicketRepo>();
            builder.Services.AddScoped<ITicketsManager,TicketManager>();
            builder.Services.AddScoped<IDepartmentManager,DepartmentManager>();
            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}