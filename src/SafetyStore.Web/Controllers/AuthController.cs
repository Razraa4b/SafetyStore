using Microsoft.AspNetCore.Mvc;
using SafetyStore.Application.DTO;

namespace SafetyStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            return Ok();
        }
    }
}
