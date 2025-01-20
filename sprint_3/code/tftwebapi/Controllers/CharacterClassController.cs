using Microsoft.AspNetCore.Mvc;
using tftwebapi.Data;
using tftwebapi.Models;
using Microsoft.EntityFrameworkCore;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterClassController : ControllerBase
    {
        private static List<PostCharacter> _characters = new List<PostCharacter>();

        // GET: api/PostCharacter
        [HttpGet]
        public ActionResult<IEnumerable<PostCharacter>> GetCharacters()
        {
            return Ok(_characters);
        }

        // GET: api/PostCharacter/5
        [HttpGet("{id}")]
        public ActionResult<PostCharacter> GetCharacter(int id)
        {
            var character = _characters.FirstOrDefault(c => c.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        // POST: api/PostCharacter
        [HttpPost]
        public ActionResult<PostCharacter> PostCharacter(PostCharacter character)
        {
            _characters.Add(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = character.CharacterId }, character);
        }

        // PUT: api/PostCharacter/5
        [HttpPut("{id}")]
        public IActionResult PutCharacter(int id, PostCharacter character)
        {
            var existingCharacter = _characters.FirstOrDefault(c => c.CharacterId == id);
            if (existingCharacter == null)
            {
                return NotFound();
            }

            existingCharacter.CharacterName = character.CharacterName;
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

            return NoContent();
        }

        // DELETE: api/PostCharacter/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            var character = _characters.FirstOrDefault(c => c.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            _characters.Remove(character);
            return NoContent();
        }
    }
}