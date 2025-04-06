using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Models;
using tftwebapinew.Database;
using tftwebapinew.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static tftwebapinew.DTO.AnomaliaLekeresWithPermissionDTO;

namespace tftwebapinew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnomaliesWpfController : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public AnomaliesWpfController(tftdatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> UpdateAnomaly([FromBody] AnomaliaWPF dto)
        {
            if (dto.PermissionLevel != 2)
            {
                return Forbid("Nincs jogosultság az anomália módosítására.");
            }

            var anomaly = await _context.Anomalies.FindAsync(dto.AnomalyId);
            if (anomaly == null)
            {
                return NotFound("Anomália nem található.");
            }

            // Frissítjük az értékeket
            anomaly.AnomalyName = dto.AnomalyName;
            anomaly.AnomalyEffect = dto.AnomalyEffect;

            await _context.SaveChangesAsync();

            return Ok("Anomália sikeresen frissítve.");
        }

    }
}
