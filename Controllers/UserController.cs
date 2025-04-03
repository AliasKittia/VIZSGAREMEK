using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Database;
using tftwebapinew.Models;

namespace tftwebapinew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public UserController(tftdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostUser>>> GetUsers()
        {
            // Exclude sensitive fields like Hash and Salt from the response
            return await _context.Set<PostUser>()
                .Select(user => new PostUser
                {
                    Id = user.Id,
                    LoginName = user.LoginName,
                    Name = user.Name,
                    PermissionId = user.PermissionId,
                    Active = user.Active,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath
                })
                .ToListAsync();
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostUser>> GetUser(int id)
        {
            var user = await _context.Set<PostUser>()
                .Select(u => new PostUser
                {
                    Id = u.Id,
                    LoginName = u.LoginName,
                    Name = u.Name,
                    PermissionId = u.PermissionId,
                    Active = u.Active,
                    Email = u.Email,
                    ProfilePicturePath = u.ProfilePicturePath
                })
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<PostUser>> CreateUser(PostUser user)
        {
            // Ensure Hash and Salt are properly set before saving
            if (string.IsNullOrEmpty(user.Hash) || string.IsNullOrEmpty(user.Salt))
            {
                return BadRequest("Hash and Salt are required.");
            }

            _context.Set<PostUser>().Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new
            {
                user.Id,
                user.LoginName,
                user.Name,
                user.PermissionId,
                user.Active,
                user.Email,
                user.ProfilePicturePath
            });
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, PostUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            // Ensure Hash and Salt are not accidentally overwritten
            var existingUser = await _context.Set<PostUser>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.Hash = existingUser.Hash;
            user.Salt = existingUser.Salt;

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

        // DELETE: api/User/{id}
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
}