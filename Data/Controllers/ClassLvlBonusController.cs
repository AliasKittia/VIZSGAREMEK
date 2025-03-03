using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Models;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassLvlBonusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassLvlBonusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassLvlBonus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostClassLvlBonus>>> GetClassLvlBonuses()
        {
            return await _context.ClassLevelBonus.ToListAsync();
        }

        // GET: api/ClassLvlBonus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostClassLvlBonus>> GetClassLvlBonus(int id)
        {
            var classLvlBonus = await _context.ClassLevelBonus.FindAsync(id);

            if (classLvlBonus == null)
            {
                return NotFound();
            }

            return classLvlBonus;
        }

        // POST: api/ClassLvlBonus
        [HttpPost]
        public async Task<ActionResult<PostClassLvlBonus>> PostClassLvlBonus(PostClassLvlBonus classLvlBonus)
        {
            _context.ClassLevelBonus.Add(classLvlBonus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassLvlBonus), new { id = classLvlBonus.ClassId }, classLvlBonus);
        }

        // PUT: api/ClassLvlBonus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassLvlBonus(int id, PostClassLvlBonus classLvlBonus)
        {
            if (id != classLvlBonus.ClassId)
            {
                return BadRequest();
            }

            _context.Entry(classLvlBonus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassLvlBonusExists(id))
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

        // DELETE: api/ClassLvlBonus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassLvlBonus(int id)
        {
            var classLvlBonus = await _context.ClassLevelBonus.FindAsync(id);
            if (classLvlBonus == null)
            {
                return NotFound();
            }

            _context.ClassLevelBonus.Remove(classLvlBonus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassLvlBonusExists(int id)
        {
            return _context.ClassLevelBonus.Any(e => e.ClassId == id);
        }
    }
}