namespace tftwebapinew.Models
{
    public class PostFullitem{
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Halfitemeffect1 { get; set; } 
        public required string Halfitemeffect2 { get; set; }
        public required string bonuseffect { get; set; }
        public required string bonuseffect1 { get; set; }
         public required string? bonuseffect2 { get; set; }
        public required string ActiveEffect { get; set; }
        public required string Fullitemimagineblob { get; set; }

        public virtual ICollection<FullitemsPartialitem> FullitemsPartialitems { get; set; } = new List<FullitemsPartialitem>();
    }
}