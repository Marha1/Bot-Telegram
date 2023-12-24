
using QuartzApp.Jobs;
using WebApplication12;
using WebApplication12.Dal.Interfaces;
using WebApplication12.Dal.Repository;
using WebApplication12.Models;

namespace Bot
{
    class Program
    {

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IBaseRepository<Employee>, EmployeRepository>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            PostcardSheduler.Start();
            Console.WriteLine("Задача запущена");
            
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
            
        }
    }
}
