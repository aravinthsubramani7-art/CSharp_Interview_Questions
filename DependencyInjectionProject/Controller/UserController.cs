// using Microsoft.AspNetCore.Mvc;
// using DependencyInjectionProject.Services;

// namespace DependencyInjectionProject.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class UserController(IEmailService emailService) : ControllerBase //this dependency injection is a modern constructor injection
//     {
//         //Although I never instantiate EmailService with new, ASP.NET Core's built-in Dependency Injection container does it for me. 
//         //When I register builder.Services.AddScoped<IEmailService, EmailService>() in program.cs, the framework knows that any time IEmailService is requested, it should create an EmailService instance and inject it into the class. 
//         //This keeps the controller loosely coupled and allows me to replace the implementation by changing the registration instead of modifying the controller code.
//         [HttpGet]
//         public IActionResult Index()
//         {
//             var result = emailService.SendEmail("Aravinth", "This is the subject", "This is the body");
//             return Ok(result);
//         }
//     }
// }

//-----------------------------------------DI injection Types------------------------------------------------------
//----------------------------------------Constructor Injection----------------------------------------------------

// using Microsoft.AspNetCore.Mvc;
// using DependencyInjectionProject.Services;

// namespace DependencyInjectionProject.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class UserController : ControllerBase
//     {      
//         private readonly IEmailService _emailService;
//         private readonly IGiftService _giftService;
//         public UserController(IEmailService emailService, IGiftService giftService)
//         {
//             _emailService = emailService;
//             _giftService = giftService;
//         }

//         [HttpGet]
//         public IActionResult Index()
//         {
//             var result1 = _emailService.SendEmail("Aravinth", "This is the subject", "This is the body"); 
//             var result2 = _giftService.SendGift();
//             return Ok(result1 + " | " + result2);
//         }
//     }
// }

//------------------------------------------Property Injection-------------------------------------------------

// using Microsoft.AspNetCore.Mvc;
// using DependencyInjectionProject.Services;

// namespace DependencyInjectionProject.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class UserController : ControllerBase
//     {      
//         [FromServices]
//         public IEmailService emailService { get; set; } = null!; //when you are go with property injection it should not be private, it should be public only
//         [FromServices] //if you forget to add this attribute, it will throw an NullReference Exception
//         public IGiftService giftService { get; set; } = null!;

//         [HttpGet]
//         public IActionResult Index()
//         {
//             var result1 = emailService.SendEmail("Aravinth", "This is the subject", "This is the body"); 
//             var result2 = giftService.SendGift();
//             return Ok(result1 + " | " + result2);
//         }
//     }
// }

//----------------------------------------Method Injection--------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using DependencyInjectionProject.Services;

namespace DependencyInjectionProject.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {      
        [HttpGet]
        public IActionResult Index([FromServices] IEmailService emailService, [FromServices] IGiftService giftService) //This is useful when the dependency is needed only for a specific method.
        { //whenever you are using [FromServices] you don't have to pass the data for those parameters from your client, but this is optional
            var result1 = emailService.SendEmail("Aravinth", "This is the subject", "This is the body"); 
            var result2 = giftService.SendGift();
            return Ok(result1 + " | " + result2);
        }
    }
}

