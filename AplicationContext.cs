using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApplication12;
namespace WebApplication12.Models
{
    public class AplicationContext:DbContext
    {
        public DbSet<Employee>Employees { get; set; }

        private readonly IConfiguration _configuration;

        public AplicationContext(DbContextOptions<AplicationContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(t => t.Id);
        }
    }
}
