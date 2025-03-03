using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public CharacterController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all characters
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var characters = _context.Characters.ToList(); // A Characters DbSet közvetlen használata
                return Ok(characters);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific character by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var character = _context.Characters.FirstOrDefault(c => c.CharacterId == id);
                if (character == null)
                    return NotFound($"Character with ID {id} not found.");
                return Ok(character);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new character
        [HttpPost]
        public IActionResult Post([FromBody] Character character)
        {
            try
            {
                if (character == null)
                    return BadRequest("Invalid character data.");

                _context.Characters.Add(character);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Character added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing character
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Character character)
        {
            try
            {
                if (id != character.CharacterId)
                    return BadRequest("ID mismatch.");

                var existingCharacter = _context.Characters.FirstOrDefault(c => c.CharacterId == id);
                if (existingCharacter == null)
                    return NotFound($"Character with ID {id} not found.");

                existingCharacter.CharacterName = character.CharacterName; // Példa: frissítés
                existingCharacter.AbilityName = character.AbilityName;
                existingCharacter.Ability = character.Ability;
                existingCharacter.Cost = character.Cost;
                existingCharacter.Health = character.Health;
                existingCharacter.Health1 = character.Health1;
                existingCharacter.Health2 = character.Health2;
                existingCharacter.AttackSpeed = character.AttackSpeed;
                existingCharacter.Damage = character.Damage;
                existingCharacter.Damage1 = character.Damage1;
                existingCharacter.Damage2 = character.Damage2;
                existingCharacter.AbilityPower = character.AbilityPower;
                existingCharacter.ManaStart = character.ManaStart;
                existingCharacter.ManaMax = character.ManaMax;
                existingCharacter.Armor = character.Armor;
                existingCharacter.MagicResist = character.MagicResist;
                existingCharacter.Range = character.Range;
                existingCharacter.Characterimageblob = character.Characterimageblob;

                _context.Characters.Update(existingCharacter);
                _context.SaveChanges();
                return Ok("Character updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete a character by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var character = _context.Characters.FirstOrDefault(c => c.CharacterId == id);
                if (character == null)
                    return NotFound($"Character with ID {id} not found.");

                _context.Characters.Remove(character);
                _context.SaveChanges();
                return Ok($"Character with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
