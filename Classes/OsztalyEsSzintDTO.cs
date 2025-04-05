using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karbantarto.Classes
{
    namespace ProjectName_Backend.DTOs
    {
        public class OsztalyDTO
        {
            public int ClassID { get; set; }
            public string ClassName { get; set; } = null!;
            public string? BasicEffect { get; set; }
            public string? Classimageblob { get; set; }
            public List<SzintDTO> Szintek { get; set; } = new List<SzintDTO>();
            public List<KarakterDTO> Karakterek { get; set; } = new List<KarakterDTO>();
        }

        public class SzintDTO
        {
            public int Level { get; set; }
            public int? CharacterCount { get; set; }
            public string? BonusEffect { get; set; }
        }

        public class KarakterDTO
        {
            public int CharacterId { get; set; }
            public string CharacterName { get; set; } = null!;
            public string? Characterimageblob { get; set; }
        }


    }
}
