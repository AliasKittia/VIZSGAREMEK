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
    public class FullitemsController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public FullitemsController(tftdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Fullitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostFullitem>>> GetFullitems()
        {
            return await _context.FullItems.ToListAsync();
        }

        // GET: api/Fullitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostFullitem>> GetFullitem(int id)
        {
            var fullitem = await _context.FullItems.FindAsync(id);

            if (fullitem == null)
            {
                return NotFound();
            }

            return fullitem;
        }

        // POST: api/Fullitems
        [HttpPost]
        public async Task<ActionResult<PostFullitem>> PostFullitem(PostFullitem fullitem)
        {
            _context.FullItems.Add(fullitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFullitem), new { id = fullitem.Id }, fullitem);
        }

        // PUT: api/Fullitems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFullitem(int id, PostFullitem fullitem)
        {
            if (id != fullitem.Id)
            {
                return BadRequest();
            }

            _context.Entry(fullitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FullitemExists(id))
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

        // DELETE: api/Fullitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFullitem(int id)
        {
            var fullitem = await _context.FullItems.FindAsync(id);
            if (fullitem == null)
            {
                return NotFound();
            }

            _context.FullItems.Remove(fullitem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FullitemExists(int id)
        {
            return _context.FullItems.Any(e => e.Id == id);
        }
    }
}