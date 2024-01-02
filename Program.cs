using Microsoft.EntityFrameworkCore;
using QuartzApp.Jobs;
using WebApplication12.Dal.Interfaces;
using WebApplication12.Dal.Repository;
using WebApplication12.Models;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile("appsettings.json");

        builder.Services.AddDbContext<AplicationContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Замените создание экземпляра EmployeRepository на использование DI
        builder.Services.AddScoped<IBaseRepository<Employee>, EmployeRepository>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        var app = builder.Build();
        PostcardSheduler.Start();
        Console.WriteLine("Задача запущена");
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}
