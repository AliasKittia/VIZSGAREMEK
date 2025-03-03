using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Models;


namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostClass>>> GetClasses()
        {
            return await _context.Class.ToListAsync();
        }

        // GET: api/Class/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostClass>> GetClass(int id)
        {
            var postClass = await _context.Class.FindAsync(id);

            if (postClass == null)
            {
                return NotFound();
            }

            return postClass;
        }

        // POST: api/Class
        [HttpPost]
        public async Task<ActionResult<PostClass>> PostClass(PostClass postClass)
        {
            _context.Class.Add(postClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClass), new { id = postClass.ClassId }, postClass);
        }

        // PUT: api/Class/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, PostClass postClass)
        {
            if (id != postClass.ClassId)
            {
                return BadRequest();
            }

            _context.Entry(postClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // DELETE: api/Class/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var postClass = await _context.Class.FindAsync(id);
            if (postClass == null)
            {
                return NotFound();
            }

            _context.Class.Remove(postClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.ClassId == id);
        }
    }
}