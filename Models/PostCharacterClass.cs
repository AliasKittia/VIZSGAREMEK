using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tftwebapinew.Models
{
     public class PostCharacterClass
    {
        [Key]
        [Column(Order = 0)]
        public int CharacterID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ClassID { get; set; }
    }
}
