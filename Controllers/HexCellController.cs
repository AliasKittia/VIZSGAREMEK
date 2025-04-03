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
    public class HexCellController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public HexCellController(tftdatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostHexCell>>> GetHexCells()
        {
            return await _context.hexCells.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostHexCell>> GetHexCell(int id)
        {
            var hexCell = await _context.hexCells.FindAsync(id);

            if (hexCell == null)
            {
                return NotFound();
            }

            return hexCell;
        }

        [HttpPost]
        public async Task<ActionResult<PostHexCell>> PostHexCell(PostHexCell hexCell)
        {
            _context.hexCells.Add(hexCell);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHexCell), new { id = hexCell.Id }, hexCell);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHexCell(int id, PostHexCell hexCell)
        {
            if (id != hexCell.Id)
            {
                return BadRequest();
            }

            _context.Entry(hexCell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.hexCells.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHexCell(int id)
        {
            var hexCell = await _context.hexCells.FindAsync(id);
            if (hexCell == null)
            {
                return NotFound();
            }

            _context.hexCells.Remove(hexCell);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}