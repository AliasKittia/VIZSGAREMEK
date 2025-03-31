namespace tftwebapinew.Models
{
    public class FullitemsPartialitem
    {
        public int Id { get; set; }

        public int FullItemId { get; set; }

        public int PartialItemId1 { get; set; }

        public int PartialItemId2 { get; set; }

        public virtual PostFullitem FullItem { get; set; } = null!;

        public virtual PostPartialitem PartialItemId1Navigation { get; set; } = null!;

        public virtual PostPartialitem PartialItemId2Navigation { get; set; } = null!;
    }
}
