using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartialItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PartialItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PostPartialItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostPartialItems>>> GetItems()
        {
            return await _context.PartialItems.ToListAsync();
        }

        // GET: api/PostPartialItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostPartialItems>> GetItem(int id)
        {
            var item = await _context.PartialItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/PostPartialItems
        [HttpPost]
        public async Task<ActionResult<PostPartialItems>> PostItem(PostPartialItems item)
        {
            _context.PartialItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.partial_item_id }, item);
        }

        // PUT: api/PostPartialItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, PostPartialItems item)
        {
            if (id != item.partial_item_id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // DELETE: api/PostPartialItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.PartialItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.PartialItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.PartialItems.Any(e => e.partial_item_id == id);
        }
    }
}