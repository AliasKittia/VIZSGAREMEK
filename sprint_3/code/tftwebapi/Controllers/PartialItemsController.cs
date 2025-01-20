using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Models;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartialItemsController : ControllerBase
    {
        private static List<PostPartialItems> _items = new List<PostPartialItems>();

        // GET: api/PostPartialItems
        [HttpGet]
        public ActionResult<IEnumerable<PostPartialItems>> GetItems()
        {
            return Ok(_items);
        }

        // GET: api/PostPartialItems/5
        [HttpGet("{id}")]
        public ActionResult<PostPartialItems> GetItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.partial_item_id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/PostPartialItems
        [HttpPost]
        public ActionResult<PostPartialItems> PostItem(PostPartialItems item)
        {
            _items.Add(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.partial_item_id }, item);
        }

        // PUT: api/PostPartialItems/5
        [HttpPut("{id}")]
        public IActionResult PutItem(int id, PostPartialItems item)
        {
            var existingItem = _items.FirstOrDefault(i => i.partial_item_id == id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.name = item.name;
            existingItem.effect = item.effect;

            return NoContent();
        }

        // DELETE: api/PostPartialItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.partial_item_id == id);
            if (item == null)
            {
                return NotFound();
            }

            _items.Remove(item);
            return NoContent();
        }
    }
}