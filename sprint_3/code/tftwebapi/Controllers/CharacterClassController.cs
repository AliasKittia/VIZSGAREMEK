using Microsoft.AspNetCore.Mvc;
using tftwebapi.Data;
using tftwebapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PostCharacter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostCharacter>>> GetCharacters()
        {
            return await _context.Character.ToListAsync();
        }

        // GET: api/PostCharacter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostCharacter>> GetCharacter(int id)
        {
            var character = await _context.Character.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // POST: api/PostCharacter
        [HttpPost]
        public async Task<ActionResult<PostCharacter>> PostCharacter(PostCharacter character)
        {
            _context.Character.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacter), new { id = character.CharacterId }, character);
        }

        // PUT: api/PostCharacter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, PostCharacter character)
        {
            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PostCharacter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Character.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.CharacterId == id);
        }
    }
}