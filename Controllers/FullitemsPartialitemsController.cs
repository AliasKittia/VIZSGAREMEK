using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models;

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FullitemsPartialitemController : ControllerBase
    {
        private readonly TftdatabaseContext _context;

        // A DbContext DI általi injektálása
        public FullitemsPartialitemController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get all the FullitemsPartialitem relationships
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var fullItemsPartialItems = _context.FullitemsPartialitems
                    .Include(f => f.FullItem)
                    .Include(p => p.PartialItemId1Navigation)
                    .Include(p => p.PartialItemId2Navigation)
                    .ToList(); // A FullitemsPartialitem és a kapcsolódó Fullitem és Partialitemek betöltése
                return Ok(fullItemsPartialItems);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific FullitemsPartialitem by FullItemId and PartialItemId
        [HttpGet("{fullItemId}/{partialItemId1}/{partialItemId2}")]
        public IActionResult Get(int fullItemId, int partialItemId1, int partialItemId2)
        {
            try
            {
                var fullItemsPartialItem = _context.FullitemsPartialitems
                    .FirstOrDefault(f => f.FullItemId == fullItemId && f.PartialItemId1 == partialItemId1 && f.PartialItemId2 == partialItemId2);

                if (fullItemsPartialItem == null)
                    return NotFound("FullitemsPartialitem not found.");
                return Ok(fullItemsPartialItem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new FullitemsPartialitem
        [HttpPost]
        public IActionResult Post([FromBody] FullitemsPartialitem fullItemsPartialItem)
        {
            try
            {
                if (fullItemsPartialItem == null)
                    return BadRequest("Invalid FullitemsPartialitem data.");

                _context.FullitemsPartialitems.Add(fullItemsPartialItem);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "FullitemsPartialitem added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // Delete a FullitemsPartialitem by FullItemId and PartialItemId
        [HttpDelete("{fullItemId}/{partialItemId1}/{partialItemId2}")]
        public IActionResult Delete(int fullItemId, int partialItemId1, int partialItemId2)
        {
            try
            {
                var fullItemsPartialItem = _context.FullitemsPartialitems
                    .FirstOrDefault(f => f.FullItemId == fullItemId && f.PartialItemId1 == partialItemId1 && f.PartialItemId2 == partialItemId2);

                if (fullItemsPartialItem == null)
                    return NotFound("FullitemsPartialitem not found.");

                _context.FullitemsPartialitems.Remove(fullItemsPartialItem);
                _context.SaveChanges();
                return Ok("FullitemsPartialitem deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
