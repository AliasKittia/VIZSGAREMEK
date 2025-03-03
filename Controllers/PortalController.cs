using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartialitemController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public PartialitemController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all partial items
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var partialItems = _context.Partialitems.ToList(); // A Partialitems DbSet közvetlen használata
                return Ok(partialItems);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific partial item by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var partialItem = _context.Partialitems
                    .Include(p => p.FullitemsPartialitemPartialItemId1Navigations) // Betöltjük a kapcsolódó FullitemsPartialitem entitásokat
                    .Include(p => p.FullitemsPartialitemPartialItemId2Navigations) // Betöltjük a másik kapcsolódó FullitemsPartialitem entitásokat
                    .FirstOrDefault(p => p.PartialItemId == id);

                if (partialItem == null)
                    return NotFound($"Partial item with ID {id} not found.");

                return Ok(partialItem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new partial item
        [HttpPost]
        public IActionResult Post([FromBody] Partialitem partialItem)
        {
            try
            {
                if (partialItem == null)
                    return BadRequest("Invalid partial item data.");

                _context.Partialitems.Add(partialItem);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Partial item added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing partial item
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Partialitem partialItem)
        {
            try
            {
                if (id != partialItem.PartialItemId)
                    return BadRequest("ID mismatch.");

                var existingPartialItem = _context.Partialitems.FirstOrDefault(p => p.PartialItemId == id);
                if (existingPartialItem == null)
                    return NotFound($"Partial item with ID {id} not found.");

                existingPartialItem.Name = partialItem.Name; // Példa: frissítés
                existingPartialItem.Effect = partialItem.Effect;
                existingPartialItem.HalfItemimageblob = partialItem.HalfItemimageblob;

                _context.Partialitems.Update(existingPartialItem);
                _context.SaveChanges();
                return Ok("Partial item updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete a partial item by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var partialItem = _context.Partialitems.FirstOrDefault(p => p.PartialItemId == id);
                if (partialItem == null)
                    return NotFound($"Partial item with ID {id} not found.");

                _context.Partialitems.Remove(partialItem);
                _context.SaveChanges();
                return Ok($"Partial item with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
