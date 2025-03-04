using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models; // A megfelelő névteret importáljuk

namespace ProjectName_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnomalyController : ControllerBase
    {
        private readonly TftdatabaseContext _context; // Használjuk a TftdatabaseContext-et

        // A DbContext DI általi injektálása
        public AnomalyController(TftdatabaseContext context)
        {
            _context = context;
        }

        // Get a list of all anomalies
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var anomalies = _context.Anomalies.ToList(); // Az Anomalies DbSet közvetlen használata
                return Ok(anomalies);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Get a specific anomaly by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var anomaly = _context.Anomalies.FirstOrDefault(a => a.AnomalyId == id);
                if (anomaly == null)
                    return NotFound($"Anomaly with ID {id} not found.");
                return Ok(anomaly);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Add a new anomaly
        [HttpPost]
        public IActionResult Post([FromBody] Anomaly anomaly)
        {
            try
            {
                if (anomaly == null)
                    return BadRequest("Invalid anomaly data.");

                _context.Anomalies.Add(anomaly);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Anomaly added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); // 500 - Internal Server Error
            }
        }

        // Update an existing anomaly
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Anomaly anomaly)
        {
            try
            {
                if (id != anomaly.AnomalyId)
                    return BadRequest("ID mismatch.");

                var existingAnomaly = _context.Anomalies.FirstOrDefault(a => a.AnomalyId == id);
                if (existingAnomaly == null)
                    return NotFound($"Anomaly with ID {id} not found.");

                existingAnomaly.AnomalyName = anomaly.AnomalyName; // Példa: frissítés
                existingAnomaly.AnomalyEffect = anomaly.AnomalyEffect;
                _context.Anomalies.Update(existingAnomaly);
                _context.SaveChanges();
                return Ok("Anomaly updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Delete an anomaly by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var anomaly = _context.Anomalies.FirstOrDefault(a => a.AnomalyId == id);
                if (anomaly == null)
                    return NotFound($"Anomaly with ID {id} not found.");

                _context.Anomalies.Remove(anomaly);
                _context.SaveChanges();
                return Ok($"Anomaly with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
