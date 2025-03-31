using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Models;
using tftwebapinew.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tftwebapinew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public ClassController(tftdatabaseContext context)
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
            var classEntity = await _context.Class.FindAsync(id);

            if (classEntity == null)
            {
                return NotFound();
            }

            return classEntity;
        }

        // POST: api/Class
        [HttpPost]
        public async Task<ActionResult<PostClass>> PostClass(PostClass classEntity)
        {
            _context.Class.Add(classEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClass), new { id = classEntity.ClassID }, classEntity);
        }

        // PUT: api/Class/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, PostClass classEntity)
        {
            if (id != classEntity.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(classEntity).State = EntityState.Modified;

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
            var classEntity = await _context.Class.FindAsync(id);
            if (classEntity == null)
            {
                return NotFound();
            }

            _context.Class.Remove(classEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.ClassID == id);
        }
    }
}