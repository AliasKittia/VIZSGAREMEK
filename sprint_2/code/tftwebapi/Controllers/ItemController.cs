using Microsoft.AspNetCore.Mvc;
using tftwebapi.Models;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly List<PostItem> _items;

    public ItemsController()
    {
        // Initialize items with correct image paths
        _items = new List<PostItem>
        {
            new PostItem
            {
                Id = 1,
                Name = "B.F. Sword",
                Icon = "/images/BFSword.png", // Correct path for static files
                Description = "Attack damage",
                Effects = "+10 AD"
            },
            new PostItem
            {
                Id = 2,
                Name = "Chain Vest",
                Icon = "/images/ChainVest.png", // Correct path for static files
                Description = "Armor",
                Effects = "+20 Armor"
            }
        };
    }

    [HttpGet]
    public ActionResult<IEnumerable<PostItem>> GetItems()
    {
        return Ok(_items);
    }

    [HttpPost("combine")]
    public ActionResult<PostItem> CombineItems([FromBody] List<int> componentIds)
    {
        var item = _items.FirstOrDefault(i => i.Components.SequenceEqual(componentIds));
        if (item == null) return NotFound("No item matches the provided components.");
        return Ok(item);
    }
}
