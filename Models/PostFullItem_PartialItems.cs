namespace tftwebapi.Models
{
    public class PostFullItem_PartialItems
    {
        public required int Id { get; set; }
        public required int FullItemId { get; set; }
        public required int PartialItemId1 { get; set; } 
        public required int PartialItemId2 { get; set; }
    }
}