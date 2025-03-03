using Microsoft.AspNetCore.Mvc;
using tftwebapi.Data;
using tftwebapi.Models;
using Microsoft.EntityFrameworkCore;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AugmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AugmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PostAugments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostAugments>>> GetAugments()
        {
            return await _context.Augments.ToListAsync();
        }

        // GET: api/PostAugments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostAugments>> GetAugment(int id)
        {
            var augment = await _context.Augments.FindAsync(id);

            if (augment == null)
            {
                return NotFound();
            }

            return augment;
        }

        // POST: api/PostAugments
        [HttpPost]
        public async Task<ActionResult<PostAugments>> PostAugment(PostAugments augment)
        {
            _context.Augments.Add(augment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAugment), new { id = augment.AugmentId }, augment);
        }

        // PUT: api/PostAugments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAugment(int id, PostAugments augment)
        {
            if (id != augment.AugmentId)
            {
                return BadRequest();
            }

            _context.Entry(augment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AugmentExists(id))
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

        // DELETE: api/PostAugments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAugment(int id)
        {
            var augment = await _context.Augments.FindAsync(id);
            if (augment == null)
            {
                return NotFound();
            }

            _context.Augments.Remove(augment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AugmentExists(int id)
        {
            return _context.Augments.Any(e => e.AugmentId == id);
        }
    }
}