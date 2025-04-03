using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                        Classimageblob = c.Classimageblob != null ? new string[] { c.Classimageblob } : null,
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
                            Characterimageblob = ch.Characterimageblob != null ? new string[] { ch.Characterimageblob } : null
                        }).ToList()
                    })
                    .ToListAsync();

                return osztalyok.Any() ? Ok(osztalyok) : NotFound("No classes found in the database.");
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
                        Classimageblob = c.Classimageblob != null ? new string[] { c.Classimageblob } : null,
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
                            Characterimageblob = ch.Characterimageblob != null ? new string[] { ch.Characterimageblob } : null
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

                return osztaly != null ? Ok(osztaly) : NotFound($"Class with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}