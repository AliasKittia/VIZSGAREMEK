using Microsoft.AspNetCore.Mvc;

namespace tftwebapinew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        [HttpPost]
        public IActionResult Logout()
        {
            // Implement logout logic if needed (e.g., token invalidation)
            return Ok("User logged out successfully.");
        }
    }
}