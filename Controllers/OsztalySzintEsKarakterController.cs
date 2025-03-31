using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Models;
using tftwebapinew.DTO;
using tftwebapinew.Database;
namespace tftwebapinew.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OsztalySzintEsKarakterController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public OsztalySzintEsKarakterController(tftdatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OsztalyDTO>>> GetOsztalyok()
        {
            try
            {
                var osztalyok = await _context.Class
                   .AsNoTracking()
                    .Include(c => c.Classlevelbonus)
                    .Include(c => c.Characters)
                    .Select(c => new OsztalyDTO
                    {
                        ClassId = c.ClassId,
                        ClassName = c.ClassName,
                        BasicEffect = c.BasicEffect,
                        Classimageblob = new string[] { c.Classimageblob },
                        Szintek = c.Classlevelbonus.Select(cl => new SzintDTO
                        {
                            Level = cl.Level,
                            CharacterCount = cl.CharacterCount,
                            BonusEffect = cl.BonusEffect
                        }).ToList(),
                        Karakterek = c.Characters.Select(ch => new KarakterDTO
                        {
                            CharacterId = ch.CharacterID,
                            CharacterName = ch.CharacterName,
                            Characterimageblob = new string[] { ch.Characterimageblob }
                        }).ToList()
                    })
                    .ToListAsync();

                if (osztalyok == null || !osztalyok.Any())
                {
                    return NotFound("No classes found in the database.");
                }

                return Ok(osztalyok);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OsztalyDTO>> GetOsztaly(int id)
        {
            try
            {
                var osztaly = await _context.Class
                    .AsNoTracking()
                    .Include(c => c.Classlevelbonus)
                    .Include(c => c.Characters)
                    .Where(c => c.ClassId == id)
                    .Select(c => new OsztalyDTO
                    {
                        ClassId = c.ClassId,
                        ClassName = c.ClassName,
                        BasicEffect = c.BasicEffect,
                        Classimageblob = new string[] { c.Classimageblob },
                        Szintek = c.Classlevelbonus.Select(cl => new SzintDTO
                        {
                            Level = cl.Level,
                            CharacterCount = cl.CharacterCount,
                            BonusEffect = cl.BonusEffect
                        }).ToList(),
                        Karakterek = c.Characters.Select(ch => new KarakterDTO
                        {
                            CharacterId = ch.CharacterID,
                            CharacterName = ch.CharacterName,
                            Characterimageblob = new string[] { ch.Characterimageblob }
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (osztaly == null)
                {
                    return NotFound($"Class with ID {id} not found.");
                }

                return Ok(osztaly);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}