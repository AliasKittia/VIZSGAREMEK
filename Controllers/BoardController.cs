using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public BoardController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all boards
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var boards = _context.Boards.Include(b => b.IdNavigation).ToList(); // A Boards DbSet és a kapcsolódó User entitás betöltése
                return Ok(boards);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific board by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var board = _context.Boards
                    .Include(b => b.IdNavigation) // Betöltjük a kapcsolódó User entitást
                    .FirstOrDefault(b => b.BoardId == id);

                if (board == null)
                    return NotFound($"Board with ID {id} not found.");

                return Ok(board);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new board
        [HttpPost]
        public IActionResult Post([FromBody] Board board)
        {
            try
            {
                if (board == null)
                    return BadRequest("Invalid board data.");

                _context.Boards.Add(board);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Board added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing board
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Board board)
        {
            try
            {
                if (id != board.BoardId)
                    return BadRequest("ID mismatch.");

                var existingBoard = _context.Boards.FirstOrDefault(b => b.BoardId == id);
                if (existingBoard == null)
                    return NotFound($"Board with ID {id} not found.");

                existingBoard.Boardname = board.Boardname; // Példa: frissítés
                existingBoard.IdNavigation = board.IdNavigation;

                _context.Boards.Update(existingBoard);
                _context.SaveChanges();
                return Ok("Board updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete a board by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var board = _context.Boards.FirstOrDefault(b => b.BoardId == id);
                if (board == null)
                    return NotFound($"Board with ID {id} not found.");

                _context.Boards.Remove(board);
                _context.SaveChanges();
                return Ok($"Board with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
