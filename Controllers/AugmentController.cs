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
    public class AugmentController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public AugmentController(tftdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Augment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostAugment>>> GetAugments()
        {
            return await _context.Augments.ToListAsync();
        }

        // GET: api/Augment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostAugment>> GetAugment(int id)
        {
            var augment = await _context.Augments.FindAsync(id);

            if (augment == null)
            {
                return NotFound();
            }

            return augment;
        }

        // POST: api/Augment
        [HttpPost]
        public async Task<ActionResult<PostAugment>> PostAugment(PostAugment augment)
        {
            _context.Augments.Add(augment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAugment), new { id = augment.AugmentId }, augment);
        }

        // PUT: api/Augment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAugment(int id, PostAugment augment)
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

        // DELETE: api/Augment/5
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