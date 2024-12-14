using Microsoft.AspNetCore.Mvc;
using tftwebapi.Models; 

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase {
    private readonly List<PostItem> _items = new List<PostItem> {
        new PostItem { Id = 1, Name = "B.F. Sword", Icon = "bf_sword.png", Description = "Attack damage", Effects = "+10 AD" },
        new PostItem { Id = 2, Name = "Chain Vest", Icon = "chain_vest.png", Description = "Armor", Effects = "+20 Armor" },
        new PostItem { Id = 3, Name = "Infinity Edge", Icon = "infinity_edge.png", Components = new List<int> { 1, 1 }, Description = "Critical Strike", Effects = "Increases crit chance" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<PostItem>> GetItems() {
        return Ok(_items);
    }

    [HttpPost("combine")]
    public ActionResult<PostItem> CombineItems([FromBody] List<int> componentIds) {
        var item = _items.FirstOrDefault(i => i.Components.SequenceEqual(componentIds));
        if (item == null) return NotFound("No item matches the provided components.");
        return Ok(item);
    }
}
