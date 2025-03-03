using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public ClassController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all classes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var classes = _context.Classes.ToList(); // A Classes DbSet közvetlen használata
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific class by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var classEntity = _context.Classes
                    .Include(c => c.Classlevelbonus) // Ha szükséges, betöltjük a kapcsolódó Classlevelbonus entitásokat
                    .Include(c => c.Characters) // Ha szükséges, betöltjük a kapcsolódó Character entitásokat
                    .FirstOrDefault(c => c.ClassId == id);

                if (classEntity == null)
                    return NotFound($"Class with ID {id} not found.");

                return Ok(classEntity);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new class
        [HttpPost]
        public IActionResult Post([FromBody] Class classEntity)
        {
            try
            {
                if (classEntity == null)
                    return BadRequest("Invalid class data.");

                _context.Classes.Add(classEntity);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Class added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing class
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Class classEntity)
        {
            try
            {
                if (id != classEntity.ClassId)
                    return BadRequest("ID mismatch.");

                var existingClass = _context.Classes.FirstOrDefault(c => c.ClassId == id);
                if (existingClass == null)
                    return NotFound($"Class with ID {id} not found.");

                existingClass.ClassName = classEntity.ClassName; // Példa: frissítés
                existingClass.BasicEffect = classEntity.BasicEffect;
                existingClass.Classimageblob = classEntity.Classimageblob;

                _context.Classes.Update(existingClass);
                _context.SaveChanges();
                return Ok("Class updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete a class by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var classEntity = _context.Classes.FirstOrDefault(c => c.ClassId == id);
                if (classEntity == null)
                    return NotFound($"Class with ID {id} not found.");

                _context.Classes.Remove(classEntity);
                _context.SaveChanges();
                return Ok($"Class with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
