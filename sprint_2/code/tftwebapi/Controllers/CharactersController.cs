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
            Name = "Amumu",
            Picture = "/images/Amumu.png", // Relative to wwwroot
            Cost = 1,
            Items = new List<string> { "Dragons's Claw", "Gargoyle Stoneplate", "Warmog's Armor" },
            Health = new List<int> { 600, 1080, 1944 },
            Mana = 0,
            Armor = 35,
            MR = 35,
            DPS = new List<int> { 27, 49, 87 },
            Damage = new List<int> { 45, 81, 146 },
            AtkSpd = 0.6f,
            CritRate = 0.25f,
            Range = 1
        },
        new PostCharacter {
            Id = 2,
            Name = "Akali",
            Picture = "/images/Akali.png", // Relative to wwwroot
            Cost = 2,
            Items = new List<string> { "Hand of Justice", "Ionic Spark","Jeweled Gauntlet" },
            Health = new List<int> { 700, 1260, 2268 },
            Mana = 60,
            Armor = 45,
            MR = 45,
            DPS = new List<int> { 34, 61, 109 },
            Damage = new List<int> { 45, 81, 146 },
            AtkSpd = 0.75f,
            CritRate = 0.25f,
            Range = 1
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
