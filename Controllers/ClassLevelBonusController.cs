using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClasslevelbonuController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public ClasslevelbonuController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all class level bonuses
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var classLevelBonuses = _context.Classlevelbonus.Include(c => c.Class).ToList(); // A Classlevelbonu DbSet és a kapcsolódó Class entitás betöltése
                return Ok(classLevelBonuses);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific class level bonus by ClassId and Level
        [HttpGet("{classId}/{level}")]
        public IActionResult Get(int classId, int level)
        {
            try
            {
                var classLevelBonus = _context.Classlevelbonus
                    .Include(c => c.Class) // Betöltjük a kapcsolódó Class entitást
                    .FirstOrDefault(c => c.ClassId == classId && c.Level == level);

                if (classLevelBonus == null)
                    return NotFound($"Class level bonus for Class ID {classId} and Level {level} not found.");

                return Ok(classLevelBonus);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new class level bonus
        [HttpPost]
        public IActionResult Post([FromBody] Classlevelbonu classLevelBonus)
        {
            try
            {
                if (classLevelBonus == null)
                    return BadRequest("Invalid class level bonus data.");

                _context.Classlevelbonus.Add(classLevelBonus);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Class level bonus added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing class level bonus
        [HttpPut("{classId}/{level}")]
        public IActionResult Put(int classId, int level, [FromBody] Classlevelbonu classLevelBonus)
        {
            try
            {
                if (classId != classLevelBonus.ClassId || level != classLevelBonus.Level)
                    return BadRequest("ID or Level mismatch.");

                var existingClassLevelBonus = _context.Classlevelbonus
                    .FirstOrDefault(c => c.ClassId == classId && c.Level == level);

                if (existingClassLevelBonus == null)
                    return NotFound($"Class level bonus for Class ID {classId} and Level {level} not found.");

                existingClassLevelBonus.CharacterCount = classLevelBonus.CharacterCount;
                existingClassLevelBonus.BonusEffect = classLevelBonus.BonusEffect;

                _context.Classlevelbonus.Update(existingClassLevelBonus);
                _context.SaveChanges();
                return Ok("Class level bonus updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete a class level bonus by ClassId and Level
        [HttpDelete("{classId}/{level}")]
        public IActionResult Delete(int classId, int level)
        {
            try
            {
                var classLevelBonus = _context.Classlevelbonus
                    .FirstOrDefault(c => c.ClassId == classId && c.Level == level);

                if (classLevelBonus == null)
                    return NotFound($"Class level bonus for Class ID {classId} and Level {level} not found.");

                _context.Classlevelbonus.Remove(classLevelBonus);
                _context.SaveChanges();
                return Ok($"Class level bonus for Class ID {classId} and Level {level} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
