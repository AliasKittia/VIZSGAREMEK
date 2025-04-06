using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using tftwebapinew.Database;
using tftwebapinew.Models;

namespace tftwebapinew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterClassController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public CharacterClassController(tftdatabaseContext context)
        {
            _context = context;
        }

        // Összes karakter-osztály kapcsolat lekérdezése
        [HttpGet]
        public ActionResult<IEnumerable<PostCharacterClass>> GetAll()
        {
            return _context.CharacterClass.ToList();
        }

        // Egy adott karakterhez tartozó osztályok lekérdezése
        [HttpGet("character/{characterId}")]
        public ActionResult<IEnumerable<PostClass>> GetClassesByCharacter(int characterId)
        {
            var classes = _context.CharacterClass
                .Where(cc => cc.CharacterID == characterId)
                .Join(_context.Class, cc => cc.ClassID, c => c.ClassId, (cc, c) => c)
                .ToList();

            return classes.Any() ? Ok(classes) : NotFound();
        }

        // Egy adott osztályhoz tartozó karakterek lekérdezése
        [HttpGet("class/{classId}")]
        public ActionResult<IEnumerable<PostCharacter>> GetCharactersByClass(int classId)
        {
            var characters = _context.CharacterClass
                .Where(cc => cc.ClassID == classId)
                .Join(_context.Character, cc => cc.CharacterID, c => c.CharacterID, (cc, c) => c)
                .ToList();

            return characters.Any() ? Ok(characters) : NotFound();
        }

        // Új karakter-osztály kapcsolat létrehozása
        [HttpPost]
        public ActionResult<PostCharacterClass> Create(PostCharacterClass newCharacterClass)
        {
            if (_context.CharacterClass.Any(cc => cc.CharacterID == newCharacterClass.CharacterID && cc.ClassID == newCharacterClass.ClassID))
                return BadRequest("Kapcsolat már létezik.");

            _context.CharacterClass.Add(newCharacterClass);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), newCharacterClass);
        }

        // Kapcsolat törlése
        [HttpDelete("{characterId}/{classId}")]
        public IActionResult Delete(int characterId, int classId)
        {
            var characterClass = _context.CharacterClass.FirstOrDefault(cc => cc.CharacterID == characterId && cc.ClassID == classId);

            if (characterClass == null)
                return NotFound();

            _context.CharacterClass.Remove(characterClass);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
