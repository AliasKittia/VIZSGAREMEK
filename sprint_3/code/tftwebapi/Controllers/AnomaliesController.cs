using Microsoft.AspNetCore.Mvc;
using tftwebapi.Models;
using System.Collections.Generic;
using System.Linq;
using tdftwebapi.Models;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAnomaliesController : ControllerBase
    {
        private static List<PostAnomalies> _anomalies = new List<PostAnomalies>();

        // GET: api/PostAnomalies
        [HttpGet]
        public ActionResult<IEnumerable<PostAnomalies>> GetAnomalies()
        {
            return Ok(_anomalies);
        }

        // GET: api/PostAnomalies/5
        [HttpGet("{id}")]
        public ActionResult<PostAnomalies> GetAnomaly(int id)
        {
            var anomaly = _anomalies.FirstOrDefault(a => a.AnomalyId == id);
            if (anomaly == null)
            {
                return NotFound();
            }
            return Ok(anomaly);
        }

        // POST: api/PostAnomalies
        [HttpPost]
        public ActionResult<PostAnomalies> PostAnomaly(PostAnomalies anomaly)
        {
            _anomalies.Add(anomaly);
            return CreatedAtAction(nameof(GetAnomaly), new { id = anomaly.AnomalyId }, anomaly);
        }

        // PUT: api/PostAnomalies/5
        [HttpPut("{id}")]
        public IActionResult PutAnomaly(int id, PostAnomalies anomaly)
        {
            var existingAnomaly = _anomalies.FirstOrDefault(a => a.AnomalyId == id);
            if (existingAnomaly == null)
            {
                return NotFound();
            }

            existingAnomaly.AnomalyName = anomaly.AnomalyName;
            existingAnomaly.Effect = anomaly.Effect;

            return NoContent();
        }

        // DELETE: api/PostAnomalies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAnomaly(int id)
        {
            var anomaly = _anomalies.FirstOrDefault(a => a.AnomalyId == id);
            if (anomaly == null)
            {
                return NotFound();
            }

            _anomalies.Remove(anomaly);
            return NoContent();
        }
    }
}