using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models;
using ProjectName_Backend.DTOs;

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OsztalyController : ControllerBase
    {
        private readonly TftdatabaseContext _context;

        // A DbContext DI általi injektálása
        public OsztalyController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all classes with their bonuses
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var classes = _context.Classes
                    .Include(c => c.Classlevelbonus)  // Csatoljuk a bónuszokat
                    .ToList();

                var classDtos = classes.Select(c => new OsztalyLekeresDTO
                {
                    ClassID = c.ClassID,
                    ClassName = c.ClassName,
                    BasicEffect = c.BasicEffect,
                    Classimageblob = c.Classimageblob,
                    Classlevelbonus = c.Classlevelbonus.Select(b => new ClasslevelbonuDTO
                    {
                        Level = b.Level,
                        CharacterCount = b.CharacterCount,
                        BonusEffect = b.BonusEffect
                    }).ToList()
                }).ToList();

                return Ok(classDtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific class with its bonuses by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var classData = _context.Classes
                    .Include(c => c.Classlevelbonus)  // Csatoljuk a bónuszokat
                    .FirstOrDefault(c => c.ClassID == id);

                if (classData == null)
                    return NotFound($"Class with ID {id} not found.");

                var classDto = new OsztalyLekeresDTO
                {
                    ClassID = classData.ClassID,
                    ClassName = classData.ClassName,
                    BasicEffect = classData.BasicEffect,
                    Classimageblob = classData.Classimageblob,
                    Classlevelbonus = classData.Classlevelbonus.Select(b => new ClasslevelbonuDTO
                    {
                        Level = b.Level,
                        CharacterCount = b.CharacterCount,
                        BonusEffect = b.BonusEffect
                    }).ToList()
                };

                return Ok(classDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new class with its bonuses
        [HttpPost]
        public IActionResult Post([FromBody] OsztalyLekeresDTO classDto)
        {
            try
            {
                if (classDto == null)
                    return BadRequest("Invalid class data.");

                var classEntity = new Class
                {
                    ClassName = classDto.ClassName,
                    BasicEffect = classDto.BasicEffect,
                    Classimageblob = classDto.Classimageblob
                };

                _context.Classes.Add(classEntity);
                _context.SaveChanges();

                // Adding bonuses
                foreach (var bonusDto in classDto.Classlevelbonus)
                {
                    var bonusEntity = new Classlevelbonus
                    {
                        ClassID = classEntity.ClassID,
                        Level = bonusDto.Level,
                        CharacterCount = bonusDto.CharacterCount,
                        BonusEffect = bonusDto.BonusEffect
                    };

                    _context.Classlevelbonuses.Add(bonusEntity);
                }

                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Class added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // Update an existing class with its bonuses
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OsztalyLekeresDTO classDto)
        {
            try
            {
                if (id != classDto.ClassID)
                    return BadRequest("ID mismatch.");

                var existingClass = _context.Classes
                    .Include(c => c.Classlevelbonus) // Csatoljuk a bónuszokat
                    .FirstOrDefault(c => c.ClassID == id);

                if (existingClass == null)
                    return NotFound($"Class with ID {id} not found.");

                existingClass.ClassName = classDto.ClassName;
                existingClass.BasicEffect = classDto.BasicEffect;
                existingClass.Classimageblob = classDto.Classimageblob;

                // Bónuszok frissítése
                foreach (var bonusDto in classDto.Classlevelbonus)
                {
                    var existingBonus = existingClass.Classlevelbonus
                        .FirstOrDefault(b => b.Level == bonusDto.Level);

                    if (existingBonus != null)
                    {
                        existingBonus.CharacterCount = bonusDto.CharacterCount;
                        existingBonus.BonusEffect = bonusDto.BonusEffect;
                    }
                    else
                    {
                        var newBonus = new Classlevelbonus
                        {
                            ClassID = existingClass.ClassID,
                            Level = bonusDto.Level,
                            CharacterCount = bonusDto.CharacterCount,
                            BonusEffect = bonusDto.BonusEffect
                        };

                        _context.Classlevelbonuses.Add(newBonus);
                    }
                }

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
                var classData = _context.Classes
                    .Include(c => c.Classlevelbonus) // Csatoljuk a bónuszokat
                    .FirstOrDefault(c => c.ClassID == id);

                if (classData == null)
                    return NotFound($"Class with ID {id} not found.");

                // Először a bónuszokat töröljük
                _context.Classlevelbonuses.RemoveRange(classData.Classlevelbonus);
                _context.Classes.Remove(classData);
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
