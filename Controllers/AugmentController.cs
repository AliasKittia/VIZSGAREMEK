using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AugmentController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public AugmentController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all augments
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var augments = _context.Augments.ToList(); // Az Augments DbSet közvetlen használata
                return Ok(augments);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific augment by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var augment = _context.Augments.FirstOrDefault(a => a.AugmentId == id);
                if (augment == null)
                    return NotFound($"Augment with ID {id} not found.");
                return Ok(augment);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new augment
        [HttpPost]
        public IActionResult Post([FromBody] Augment augment)
        {
            try
            {
                if (augment == null)
                    return BadRequest("Invalid augment data.");

                _context.Augments.Add(augment);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Augment added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing augment
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Augment augment)
        {
            try
            {
                if (id != augment.AugmentId)
                    return BadRequest("ID mismatch.");

                var existingAugment = _context.Augments.FirstOrDefault(a => a.AugmentId == id);
                if (existingAugment == null)
                    return NotFound($"Augment with ID {id} not found.");

                existingAugment.AugmentName = augment.AugmentName; // Példa: frissítés
                existingAugment.AugmentRarity = augment.AugmentRarity;
                existingAugment.AugmentEffect = augment.AugmentEffect;
                _context.Augments.Update(existingAugment);
                _context.SaveChanges();
                return Ok("Augment updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete an augment by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var augment = _context.Augments.FirstOrDefault(a => a.AugmentId == id);
                if (augment == null)
                    return NotFound($"Augment with ID {id} not found.");

                _context.Augments.Remove(augment);
                _context.SaveChanges();
                return Ok($"Augment with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
