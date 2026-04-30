using Microsoft.AspNetCore.Mvc;
using HelloWebApi.Models;

namespace HelloWebApi.Controllers
{
    [ApiController]
    [Route("home")] // Bu controllerdaki eylemlere erişmek için "home" kullanılacak.
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ResponseModel GetMessage()
        {
            
            return new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP.NET Core Web API"
            };
        }
    }
}
