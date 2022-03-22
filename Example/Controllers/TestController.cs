using Feli.AspNet.Authentication.Discord;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Login() => Challenge(new AuthenticationProperties()
        {
            RedirectUri = "http://localhost:5000/test"
        });

        [HttpGet]
        public IActionResult Get() => Ok(User.Identity?.IsAuthenticated);
    }
}