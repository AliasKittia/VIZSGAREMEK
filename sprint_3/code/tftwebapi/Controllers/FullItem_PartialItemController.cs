using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tdftwebapi.Models;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullItem_PartialItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FullItem_PartialItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FullItem_PartialItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostFullItem_PartialItems>>> GetFullItem_PartialItems()
        {
            return await _context.FullItems_PartialItems.ToListAsync();
        }

        // GET: api/FullItem_PartialItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostFullItem_PartialItems>> GetFullItem_PartialItem(int id)
        {
            var fullItem_PartialItem = await _context.FullItems_PartialItems.FindAsync(id);

            if (fullItem_PartialItem == null)
            {
                return NotFound();
            }

            return fullItem_PartialItem;
        }

        // POST: api/FullItem_PartialItem
        [HttpPost]
        public async Task<ActionResult<PostFullItem_PartialItems>> PostFullItem_PartialItem(PostFullItem_PartialItems fullItem_PartialItem)
        {
            _context.FullItems_PartialItems.Add(fullItem_PartialItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFullItem_PartialItem), new { id = fullItem_PartialItem.FullItemId }, fullItem_PartialItem);
        }

        // PUT: api/FullItem_PartialItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFullItem_PartialItem(int id, PostFullItem_PartialItems fullItem_PartialItem)
        {
            if (id != fullItem_PartialItem.FullItemId)
            {
                return BadRequest();
            }

            _context.Entry(fullItem_PartialItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FullItem_PartialItemExists(id))
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

        // DELETE: api/FullItem_PartialItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFullItem_PartialItem(int id)
        {
            var fullItem_PartialItem = await _context.FullItems_PartialItems.FindAsync(id);
            if (fullItem_PartialItem == null)
            {
                return NotFound();
            }

            _context.FullItems_PartialItems.Remove(fullItem_PartialItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FullItem_PartialItemExists(int id)
        {
            return _context.FullItems_PartialItems.Any(e => e.FullItemId == id);
        }
    }
}