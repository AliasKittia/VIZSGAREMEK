using Microsoft.AspNetCore.Mvc;
using tftwebapi.Models;
using System.Collections.Generic;
using System.Linq;
using tdftwebapi.Models;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAugmentsController : ControllerBase
    {
        private static List<PostAugments> _augments = new List<PostAugments>();

        // GET: api/PostAugments
        [HttpGet]
        public ActionResult<IEnumerable<PostAugments>> GetAugments()
        {
            return Ok(_augments);
        }

        // GET: api/PostAugments/5
        [HttpGet("{id}")]
        public ActionResult<PostAugments> GetAugment(int id)
        {
            var augment = _augments.FirstOrDefault(a => a.AugmentId == id);
            if (augment == null)
            {
                return NotFound();
            }
            return Ok(augment);
        }

        // POST: api/PostAugments
        [HttpPost]
        public ActionResult<PostAugments> PostAugment(PostAugments augment)
        {
            _augments.Add(augment);
            return CreatedAtAction(nameof(GetAugment), new { id = augment.AugmentId }, augment);
        }

        // PUT: api/PostAugments/5
        [HttpPut("{id}")]
        public IActionResult PutAugment(int id, PostAugments augment)
        {
            var existingAugment = _augments.FirstOrDefault(a => a.AugmentId == id);
            if (existingAugment == null)
            {
                return NotFound();
            }

            existingAugment.AugmentName = augment.AugmentName;
            existingAugment.AugmentRarity = augment.AugmentRarity;
            existingAugment.AugmentEffect = augment.AugmentEffect;

            return NoContent();
        }

        // DELETE: api/PostAugments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAugment(int id)
        {
            var augment = _augments.FirstOrDefault(a => a.AugmentId == id);
            if (augment == null)
            {
                return NotFound();
            }

            _augments.Remove(augment);
            return NoContent();
        }
    }
}