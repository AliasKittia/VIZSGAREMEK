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
    public class BoardController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public BoardController(tftdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Board
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostBoard>>> GetBoards()
        {
            return await _context.Board.ToListAsync();
        }

        // GET: api/Board/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostBoard>> GetBoard(int id)
        {
            var board = await _context.Board.FindAsync(id);

            if (board == null)
            {
                return NotFound();
            }

            return board;
        }

        // POST: api/Board
        [HttpPost]
        public async Task<ActionResult<PostBoard>> PostBoard(PostBoard board)
        {
            _context.Board.Add(board);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoard), new { id = board.Id }, board);
        }

        // PUT: api/Board/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoard(int id, PostBoard board)
        {
            if (id != board.Id)
            {
                return BadRequest();
            }

            _context.Entry(board).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
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

        // DELETE: api/Board/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }

            _context.Board.Remove(board);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoardExists(int id)
        {
            return _context.Board.Any(e => e.Id == id);
        }
    }
}