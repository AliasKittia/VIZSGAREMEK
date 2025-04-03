using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Database;
using tftwebapinew.DTO;
using tftwebapinew.Models;

namespace tftwebapinew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsapatepitoController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public CsapatepitoController(tftdatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CsapatepitoBoardHexDTO>>> GetClasses()
        {
            return Ok(Ok(await _context.boardHexes
                .AsNoTracking()
                .Include(b => b.Id)
                .Select(b => new CsapatepitoBoardHexDTO
                {
                    Id = b.Id,
                    Board_id = b.Board_id,
                    CharacterID = b.CharacterID,
                    hex_x = b.hex_x,
                    hex_y = b.hex_y
                })
                .ToListAsync()));
        }
    }
}
