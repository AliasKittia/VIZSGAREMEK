namespace tftwebapinew.Models
{
    public class PostFullitem_Partialitem{
         public required int Id { get; set; }
        public required int FullItemId { get; set; }
        public required int PartialItemId1 { get; set; } 
        public required int PartialItemId2 { get; set; }
        public virtual ICollection<PostFullitem_Partialitem> Fullitem_Partialitems { get; set; } = new List<PostFullitem_Partialitem>(); 
    }
}