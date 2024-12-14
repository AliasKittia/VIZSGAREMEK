using Microsoft.AspNetCore.Mvc;
using tftwebapi.Models;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private static readonly List<PostCharacter> _characters = new List<PostCharacter>
    {
        new PostCharacter {
            Id = 1,
            Name = "Aatrox",
            Picture = "aatrox.png",
            Cost = 3,
            Items = new List<string> { "Infinity Edge", "Bloodthirster" },
            Health = new List<int> { 750, 1350, 2025 },
            Mana = 100,
            Armor = 40,
            MR = 40,
            DPS = new List<int> { 55, 99, 148 },
            Damage = new List<int> { 65, 117, 176 },
            AtkSpd = 0.85f,
            CritRate = 0.25f,
            Range = 1
        },
        new PostCharacter {
            Id = 2,
            Name = "Ahri",
            Picture = "ahri.png",
            Cost = 4,
            Items = new List<string> { "Blue Buff", "Jeweled Gauntlet" },
            Health = new List<int> { 650, 1170, 1755 },
            Mana = 60,
            Armor = 20,
            MR = 20,
            DPS = new List<int> { 50, 90, 135 },
            Damage = new List<int> { 50, 90, 135 },
            AtkSpd = 1.0f,
            CritRate = 0.20f,
            Range = 4
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<PostCharacter>> GetCharacters()
    {
        return Ok(_characters);
    }

    [HttpGet("{id}")]
    public ActionResult<PostCharacter> GetCharacterById(int id)
    {
        var character = _characters.FirstOrDefault(c => c.Id == id);
        if (character == null) return NotFound("Character not found.");
        return Ok(character);
    }

    [HttpPost]
    public ActionResult<PostCharacter> AddCharacter([FromBody] PostCharacter newCharacter)
    {
        if (_characters.Any(c => c.Id == newCharacter.Id))
            return BadRequest("Character with this ID already exists.");

        _characters.Add(newCharacter);
        return CreatedAtAction(nameof(GetCharacterById), new { id = newCharacter.Id }, newCharacter);
    }
}
