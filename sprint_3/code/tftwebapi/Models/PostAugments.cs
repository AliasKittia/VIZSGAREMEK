using System.Collections.Generic;
namespace tftwebapi.Models
{
    public class PostAugments
    {
        public required int AugmentId { get; set; }
        public required string AugmentName { get; set; }
        public required string AugmentRarity { get; set; }
        public required string AugmentEffect { get; set; }
        
    }
}