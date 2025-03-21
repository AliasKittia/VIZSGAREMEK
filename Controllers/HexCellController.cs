using Microsoft.AspNetCore.Mvc;
using tftwebapi.DTO;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HexCellController : ControllerBase
    {
        private static List<HexCellDTO> hexCells = new List<HexCellDTO>();

        // GET: api/HexCell
        [HttpGet]
        public ActionResult<IEnumerable<HexCellDTO>> GetHexCells()
        {
            return Ok(hexCells);
        }

        // GET: api/HexCell/5
        [HttpGet("{id}")]
        public ActionResult<HexCellDTO> GetHexCell(int id)
        {
            var hexCell = hexCells.FirstOrDefault(x => x.Id == id);
            if (hexCell == null)
            {
                return NotFound();
            }
            return Ok(hexCell);
        }

        // POST: api/HexCell
        [HttpPost]
        public ActionResult<HexCellDTO> PostHexCell(HexCellDTO hexCellDTO)
        {
            hexCellDTO.Id = hexCells.Count + 1; // Egyszerű ID-generálás
            hexCells.Add(hexCellDTO);
            return CreatedAtAction(nameof(GetHexCell), new { id = hexCellDTO.Id }, hexCellDTO);
        }

        // PUT: api/HexCell/5
        [HttpPut("{id}")]
        public IActionResult PutHexCell(int id, HexCellDTO hexCellDTO)
        {
            var existingHexCell = hexCells.FirstOrDefault(x => x.Id == id);
            if (existingHexCell == null)
            {
                return NotFound();
            }

            existingHexCell.X = hexCellDTO.X;
            existingHexCell.Y = hexCellDTO.Y;
            existingHexCell.CharacterId = hexCellDTO.CharacterId;

            return NoContent();
        }

        // DELETE: api/HexCell/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHexCell(int id)
        {
            var hexCell = hexCells.FirstOrDefault(x => x.Id == id);
            if (hexCell == null)
            {
                return NotFound();
            }

            hexCells.Remove(hexCell);
            return NoContent();
        }
    }
}
