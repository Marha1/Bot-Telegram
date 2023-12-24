using Microsoft.EntityFrameworkCore;
using WebApplication12;
namespace WebApplication12.Models
{
    public class AplicationContext:DbContext
    {
        public DbSet<Employee>Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(@"host=localhost;port=5432;database=Office;username=postgres;password=053352287");
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(t => t.Id);
        }
    }
}
