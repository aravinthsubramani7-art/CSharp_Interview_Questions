using Microsoft.AspNetCore.Mvc;
using CoachingClassAPI.Services;

namespace CoachingClassAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WithDIController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public WithDIController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudentCount()
        {
            return Ok(new
            {
                StudentCount = _studentService.GetStudentCount()
            });
        } 
    }
}