using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class EmployeeController : Controller
    {
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult AddEmploy([FromBody]Employee request)
        {
                using (AplicationContext db = new AplicationContext())
                {
                    try
                    {
                        request.Age = GetAge(request.DateOfBirh);
                        db.AddAsync(request);
                        db.SaveChanges();
                    }
                    catch (FormatException ex)
                    {

                        return new JsonResult(ex.Message);
                    }
                   
                }
                return new JsonResult("Ok");
        }
        public static int GetAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetEmploy()
        {
            using (AplicationContext db = new AplicationContext())
            {
                var task = db.Employees.ToList();
                return Ok(task);
            }
        }
        [Route("api/[controller]")]
        [HttpDelete]
        public IActionResult DeleteEmploy([FromBody]Employee request)
        {
            using (AplicationContext db = new AplicationContext())
            {
                try
                {
                    db.Employees.Remove(db.Employees.SingleOrDefault(p => p.Id == request.Id));
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
                db.SaveChanges();
                return new JsonResult("ok");
            }  
        }
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] Employee request)
        {
            using (AplicationContext db = new AplicationContext())
            {
                var result = db.Employees.FirstOrDefault(p => p.Id == request.Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    result.Name = request.Name != null ? request.Name : result.Name;
                    result.Age = request.Age != 0 ? request.Age : result.Age;
                    result.Post = request.Post != null ? request.Post : result.Post;
                    result.DateOfBirh = request.DateOfBirh != null ? request.DateOfBirh : result.DateOfBirh;
                    db.SaveChanges();
                    return new JsonResult("ok");
                }
              
            }
        }


    }
}
