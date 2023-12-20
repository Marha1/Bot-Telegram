using System.ComponentModel.DataAnnotations;
namespace WebApplication12.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public int Age { get; set; }
        [Required]

        public string? Post { get; set; }
        public DateTime DateOfBirh { get; set; }

    }
}
