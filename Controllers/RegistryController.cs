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

        // POST: api/Registry
        [HttpPost]
        public async Task<ActionResult<PostUser>> CreateUser(PostUser user)
        {
            _context.Set<PostUser>().Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
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
}