using Microsoft.AspNetCore.Mvc;
using tftwebapi.Data;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnomaliesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnomaliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PostAnomalies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostAnomalies>>> GetAnomalies()
        {
            return await _context.Anomalies.ToListAsync();
        }

        // GET: api/PostAnomalies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostAnomalies>> GetAnomaly(int id)
        {
            var anomaly = await _context.Anomalies.FindAsync(id);

            if (anomaly == null)
            {
                return NotFound();
            }

            return anomaly;
        }

        // POST: api/PostAnomalies
        [HttpPost]
        public async Task<ActionResult<PostAnomalies>> PostAnomaly(PostAnomalies anomaly)
        {
            _context.Anomalies.Add(anomaly);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnomaly), new { id = anomaly.AnomalyId }, anomaly);
        }

        // PUT: api/PostAnomalies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnomaly(int id, PostAnomalies anomaly)
        {
            if (id != anomaly.AnomalyId)
            {
                return BadRequest();
            }

            _context.Entry(anomaly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnomalyExists(id))
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

        // DELETE: api/PostAnomalies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnomaly(int id)
        {
            var anomaly = await _context.Anomalies.FindAsync(id);
            if (anomaly == null)
            {
                return NotFound();
            }

            _context.Anomalies.Remove(anomaly);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnomalyExists(int id)
        {
            return _context.Anomalies.Any(e => e.AnomalyId == id);
        }
    }
}