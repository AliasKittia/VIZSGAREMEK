using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karbantarto.Classes
{
    public class CsapatepitoKarakterDTO
    {
        public required int CharacterID { get; set; }
        public required string CharacterName { get; set; }
        public required string AbilityName { get; set; }
        public required string Ability { get; set; }
        public required int Cost { get; set; }
        public required int Health { get; set; }
        public required int Health1 { get; set; }
        public required int Health2 { get; set; }
        public required double AttackSpeed { get; set; }
        public required int Damage { get; set; }
        public required int Damage1 { get; set; }
        public required int Damage2 { get; set; }
        public required int AbilityPower { get; set; }
        public required int ManaStart { get; set; }
        public required int ManaMax { get; set; }
        public required int Armor { get; set; }
        public required int MagicResist { get; set; }
        public required int Range { get; set; }
        public required string? Characterimageblob { get; set; }
        public List<CsapatepitoOsztalyDTO> Karakterek { get; set; } = new List<CsapatepitoOsztalyDTO>();
    }

    public class CsapatepitoOsztalyDTO
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; } = null!;
        public string? BasicEffect { get; set; }
        public string? Classimageblob { get; set; }

    }

}
