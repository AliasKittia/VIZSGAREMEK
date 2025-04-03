using Microsoft.AspNetCore.Mvc;
using tftwebapinew.Models;
using tftwebapinew.Database;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace tftwebapinew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistryController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public RegistryController(tftdatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(PostUser user)
        {
            if (_context.User.Any(u => u.LoginName == user.LoginName))
            {
                return BadRequest("User with this login name already exists.");
            }

            if (_context.User.Any(u => u.Email == user.Email))
            {
                return BadRequest("User with this email already exists.");
            }

            // Generate a salt and hash the password
            var salt = GenerateSalt();
            user.Salt = salt;
            user.Hash = HashPassword(user.Password, salt);

            // Assign a default profile picture if none is provided
            if (string.IsNullOrEmpty(user.ProfilePicturePath))
            {
                user.ProfilePicturePath = "default-profile-picture.png"; // Path to the default profile picture
            }

            // Set default values for other fields if necessary
            user.Active = true; // Assuming new users are active by default
            user.PermissionId = 1; // Assuming a default permission level for new users

            // Add user to the database
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password + salt);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private string GenerateSalt()
        {
            var randomBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }
    }
}