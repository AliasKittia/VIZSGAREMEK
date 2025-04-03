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
    public class PartialitemsController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public PartialitemsController(tftdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Partialitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostPartialitem>>> GetPartialItems()
        {
            return await _context.PartialItems.ToListAsync();
        }

        // GET: api/Partialitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostPartialitem>> GetPartialItem(int id)
        {
            var partialItem = await _context.PartialItems
                .FirstOrDefaultAsync(item => item.partial_item_id == id);

            if (partialItem == null)
            {
                return NotFound();
            }

            return partialItem;
        }

        // POST: api/Partialitems
        [HttpPost]
        public async Task<ActionResult<PostPartialitem>> PostPartialItem(PostPartialitem partialItem)
        {
            _context.PartialItems.Add(partialItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPartialItem), new { id = partialItem.partial_item_id }, partialItem);
        }

        // PUT: api/Partialitems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartialItem(int id, PostPartialitem partialItem)
        {
            if (id != partialItem.partial_item_id)
            {
                return BadRequest();
            }

            _context.Entry(partialItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialItemExists(id))
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

        // DELETE: api/Partialitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartialItem(int id)
        {
            var partialItem = await _context.PartialItems
                .FirstOrDefaultAsync(item => item.partial_item_id == id);

            if (partialItem == null)
            {
                return NotFound();
            }

            _context.PartialItems.Remove(partialItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartialItemExists(int id)
        {
            return _context.PartialItems.Any(e => e.partial_item_id == id);
        }
    }
}