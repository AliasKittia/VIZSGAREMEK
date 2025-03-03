using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Models;
using tftwebapi.Services; // Add this line to include the correct namespace for FtpService

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly FtpService _ftpservice;

        public CharacterController(ApplicationDbContext context, FtpService ftpService)
        {
            _ftpservice = ftpService;
            _context = context;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostCharacter>>> GetCharacters()
        {
            return await _context.Character.ToListAsync();
            
        }

        // GET: api/Character/5
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

        // POST: api/Character
        [HttpPost]
        public async Task<ActionResult<PostCharacter>> PostCharacter(PostCharacter character)
        {
            _context.Character.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacter), new { id = character.CharacterId }, character);
        }

        // PUT: api/Character/5
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

        // DELETE: api/Character/5
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