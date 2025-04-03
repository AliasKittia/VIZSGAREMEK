using Microsoft.AspNetCore.Mvc;
using tftwebapinew.Models;

namespace tftwebapinew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Board_HexesController : ControllerBase
    {
        private static List<PostBoardHex> _boardHexes = new List<PostBoardHex>();

        // GET: api/Board_Hexes
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_boardHexes);
        }

        // GET: api/Board_Hexes/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hex = _boardHexes.FirstOrDefault(h => h.Id == id);
            if (hex == null)
            {
                return NotFound();
            }
            return Ok(hex);
        }

        // POST: api/Board_Hexes
        [HttpPost]
        public IActionResult Create([FromBody] PostBoardHex newHex)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _boardHexes.Add(newHex);
            return CreatedAtAction(nameof(GetById), new { id = newHex.Id }, newHex);
        }

        // PUT: api/Board_Hexes/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PostBoardHex updatedHex)
        {
            var hex = _boardHexes.FirstOrDefault(h => h.Id == id);
            if (hex == null)
            {
                return NotFound();
            }

            hex.Board_id = updatedHex.Board_id;
            hex.CharacterID = updatedHex.CharacterID;
            hex.hex_x = updatedHex.hex_x;
            hex.hex_y = updatedHex.hex_y;

            return NoContent();
        }

        // DELETE: api/Board_Hexes/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hex = _boardHexes.FirstOrDefault(h => h.Id == id);
            if (hex == null)
            {
                return NotFound();
            }

            _boardHexes.Remove(hex);
            return NoContent();
        }
    }
}