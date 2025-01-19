using System.Collections.Generic;

namespace tftwebapi.Models
{
    public class PostClassLvlBonus
    {

        public required int ClassId { get; set; }
        public required int Level { get; set; }
        public required int CharacterCount { get; set; }
        public required string BonusEffect { get; set; }
    }
}