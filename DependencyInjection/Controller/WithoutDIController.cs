using Microsoft.AspNetCore.Mvc;

namespace CoachingClassAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WithoutDIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudentCount()
        {
            //MathStudentService student = new MathStudentService();
            //because the requirement changed, you have to create instance for ScienceStudentService
            ScienceStudentService student = new ScienceStudentService();

            return Ok(new
            {
                // Course = "Math",
                Course = "Science",
                StudentCount = student.GetStudentCount()
            });
        }

        //concrete class
        public class MathStudentService
        {
            public int GetStudentCount()
            {
                return 50; //hardcoded
            }
        }

        //now the requirement is changed to show science student instead of Math Student
        public class ScienceStudentService
        {
            public int GetStudentCount()
            {
                return 100;
            }
        }

        //changing the class name is ok for one controller, think from enterprise application, there will be many controller we have to change many places will take more time and testing each and every controller
        //in order to solve this problem we are using DI
    }
}