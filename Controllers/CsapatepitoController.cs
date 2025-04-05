using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Database;
using tftwebapinew.DTO;
using tftwebapinew.Models;

namespace tftwebapinew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CsapatepitoBoardController : ControllerBase
    {
        public readonly tftdatabaseContext _context;

        public CsapatepitoBoardController(tftdatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CsapatepitoOsztalyDTO>>> GetOsztalyok()
        {
            try
            {
                var osztalyok = await _context.Class
                   .AsNoTracking()
                    .Include(c => c.Characters)
                    .Include(c => c.Characters)
                    .Select(c => new OsztalyDTO
                    {
                        ClassId = c.ClassId,
                        ClassName = c.ClassName,
                        BasicEffect = c.BasicEffect,
                        Classimageblob = c.Classimageblob,
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
                            Characterimageblob = ch.Characterimageblob
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
    }
}
