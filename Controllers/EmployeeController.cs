
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Dal;
using WebApplication12.Dal.Repository;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeRepository employeerepository=new EmployeRepository();
        

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult AddEmploy([FromBody]Employee request)
        {
            employeerepository.Add(request);
            return new JsonResult("Ok");

        }
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetEmploy()
        {
            var responce = employeerepository.GetAll();
            return new JsonResult(responce);
        }
        [Route("api/[controller]")]
        [HttpDelete]
        public IActionResult DeleteEmploy([FromBody]Employee request)
        {
            employeerepository.Delete(request.Id);
            return new JsonResult("Ok");
        }
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] Employee request)
        {
            employeerepository.Update(request);
            return new JsonResult("Ok");
           
        }


    }
}
