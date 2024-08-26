using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebraAdminController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDebraAdmin loginDebraAdmin)
        {
            // Simulate login validation logic
            if (loginDebraAdmin.AdminEmail == "admin@example.com" && loginDebraAdmin.AdminPassword == "password")
            {
                return Ok(new { Message = "Login successful" });
            }
            return Unauthorized(new { Message = "Invalid credentials" });
        }

        public class LoginDebraAdmin
        {
            public string AdminEmail { get; set; }
            public string AdminPassword { get; set; }
        }
    }
}
