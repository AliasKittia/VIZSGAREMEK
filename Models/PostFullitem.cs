using System.Text.Json.Serialization;

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
        public required string Fullitemimageblob { get; set; }
        [JsonIgnore]
        public virtual ICollection<PostFullitem_Partialitem> Fullitem_Partialitems { get; set; } = new List<PostFullitem_Partialitem>();
    }
}