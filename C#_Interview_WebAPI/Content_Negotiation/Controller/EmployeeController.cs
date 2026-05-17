using Microsoft.AspNetCore.Mvc;

namespace ContentNegotiationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Employee> Get()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", Position = "Software Engineer" },
                new Employee { Id = 2, Name = "Jane Smith", Position = "Project Manager" }
            };

            return Ok(employees);
        }
    }
}