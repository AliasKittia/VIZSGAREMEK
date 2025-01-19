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
    public class FullItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FullItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FullItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostFullItems>>> GetFullItems()
        {
            return await _context.FullItems.ToListAsync();
        }

        // GET: api/FullItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostFullItems>> GetFullItem(int id)
        {
            var fullItem = await _context.FullItems.FindAsync(id);

            if (fullItem == null)
            {
                return NotFound();
            }

            return fullItem;
        }

        // POST: api/FullItems
        [HttpPost]
        public async Task<ActionResult<PostFullItems>> PostFullItem(PostFullItems fullItem)
        {
            _context.FullItems.Add(fullItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFullItem), new { id = fullItem.Id }, fullItem);
        }

        // PUT: api/FullItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFullItem(int id, PostFullItems fullItem)
        {
            if (id != fullItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(fullItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FullItemExists(id))
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

        // DELETE: api/FullItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFullItem(int id)
        {
            var fullItem = await _context.FullItems.FindAsync(id);
            if (fullItem == null)
            {
                return NotFound();
            }

            _context.FullItems.Remove(fullItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FullItemExists(int id)
        {
            return _context.FullItems.Any(e => e.Id == id);
        }
    }
}