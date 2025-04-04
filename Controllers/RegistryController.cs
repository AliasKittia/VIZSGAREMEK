using Microsoft.AspNetCore.Mvc;
using tftwebapinew.Models;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Database;

namespace tftwebapinew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistryController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public RegistryController(tftdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Registry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostUser>>> GetUsers()
        {
            return await _context.Set<PostUser>().ToListAsync();
        }

        // GET: api/Registry/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostUser>> GetUser(int id)
        {
            var user = await _context.Set<PostUser>().FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Registry/Register
        [HttpPost("Register")]
        public async Task<ActionResult<PostUser>> Register([FromBody] RegisterUserDTO dto)
        {
            // Check if the provided LoginName is already in use
            if (_context.Set<PostUser>().Any(u => u.LoginName == dto.LoginName))
            {
                return BadRequest("A felhasználónév már foglalt.");
            }
            // Generate salt and compute hash from the plain-text password and salt
            var salt = Program.GenerateSalt();
            var hash = Program.CreateSHA256(dto.Password + salt);

            // Create new user record; adjust properties as needed
            var newUser = new PostUser
            {
                LoginName = dto.LoginName,
                Name = dto.Name,
                Email = dto.Email,
                Salt = salt,
                Hash = hash,
                Active = true,
                ProfilePicturePath = string.Empty,   // Set required member to a default value
                PermissionId = 1                       // Set a default PermissionId (make sure a permission with Id=1 exists)
                // ...populate any additional fields...
            };
            _context.Set<PostUser>().Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        // PUT: api/Registry/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, PostUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Registry/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Set<PostUser>().FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Set<PostUser>().Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Set<PostUser>().Any(e => e.Id == id);
        }
    }

    // DTO for registration input
    public class RegisterUserDTO
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // ...include additional fields if needed...
    }
}