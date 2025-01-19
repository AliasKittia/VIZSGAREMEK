using System.Collections.Generic;
namespace tdftwebapi.Models
{
    public class PostFullItem_PartialItems
    {
        public required int Id { get; set; }
        public required int FullItemId { get; set; }
        public required List<int> PartialItemId { get; set; } = new List<int>();
    }
}