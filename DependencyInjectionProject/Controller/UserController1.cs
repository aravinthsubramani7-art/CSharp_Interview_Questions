using Microsoft.AspNetCore.Mvc;
using DependencyInjectionProject.Services;

namespace DependencyInjectionProject.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController1(IFoodService foodService, IFoodService foodService2) : ControllerBase 
    {        
        [HttpGet]
        public IActionResult SendFood()
        {
            var result = foodService.GiveFood();
            return Ok(result); 
        }

        [HttpGet("another")]
        public IActionResult SendAnotherFood()
        {
            var result = foodService.GiveFood();
            return Ok(result);
        }
        //in this UserController1 i am using the foodService, what i want right now is i want only one instance of foodService in the entire application
        //i want to use the same instance of foodservice on both of the methods, go to prgram.cs file and i explained others there

        [HttpGet("transient")]
        public IActionResult SendTrasientFood() //for this method i have added one more instance of the same service class in the controller method
        {
            var result1 = foodService.GiveFood();
            var result2 = foodService2.GiveFood();
            return Ok(result1 + " | " + result2);
        }
    }
}