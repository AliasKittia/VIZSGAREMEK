using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FullitemController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public FullitemController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all full items
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var fullItems = _context.Fullitems.ToList(); // A Fullitems DbSet közvetlen használata
                return Ok(fullItems);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific full item by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var fullItem = _context.Fullitems
                    .Include(f => f.FullitemsPartialitems) // Betöltjük a kapcsolódó FullitemsPartialitem entitásokat
                    .FirstOrDefault(f => f.Id == id);

                if (fullItem == null)
                    return NotFound($"Full item with ID {id} not found.");

                return Ok(fullItem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new full item
        [HttpPost]
        public IActionResult Post([FromBody] Fullitem fullItem)
        {
            try
            {
                if (fullItem == null)
                    return BadRequest("Invalid full item data.");

                _context.Fullitems.Add(fullItem);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Full item added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing full item
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fullitem fullItem)
        {
            try
            {
                if (id != fullItem.Id)
                    return BadRequest("ID mismatch.");

                var existingFullItem = _context.Fullitems.FirstOrDefault(f => f.Id == id);
                if (existingFullItem == null)
                    return NotFound($"Full item with ID {id} not found.");

                existingFullItem.Name = fullItem.Name; // Példa: frissítés
                existingFullItem.Halfitemeffect1 = fullItem.Halfitemeffect1;
                existingFullItem.Halfitemeffect2 = fullItem.Halfitemeffect2;
                existingFullItem.Bonuseffect = fullItem.Bonuseffect;
                existingFullItem.Bonuseffect1 = fullItem.Bonuseffect1;
                existingFullItem.Bonuseffect2 = fullItem.Bonuseffect2;
                existingFullItem.ActiveEffect = fullItem.ActiveEffect;
                existingFullItem.Fullitemimageblob = fullItem.Fullitemimageblob;

                _context.Fullitems.Update(existingFullItem);
                _context.SaveChanges();
                return Ok("Full item updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete a full item by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var fullItem = _context.Fullitems.FirstOrDefault(f => f.Id == id);
                if (fullItem == null)
                    return NotFound($"Full item with ID {id} not found.");

                _context.Fullitems.Remove(fullItem);
                _context.SaveChanges();
                return Ok($"Full item with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
