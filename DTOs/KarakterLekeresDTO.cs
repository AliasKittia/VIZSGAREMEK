using ProjectName_Backend.Models;

namespace ProjectName_Backend.DTOs
{
    public class KarakterLekeresDTO
    {
        public int CharacterId { get; set; }

        public string CharacterName { get; set; } = null!;

        public string? AbilityName { get; set; }

        public string? Ability { get; set; }

        public int? Cost { get; set; }

        public int? Health { get; set; }

        public int? Health1 { get; set; }

        public int? Health2 { get; set; }

        public double? AttackSpeed { get; set; }

        public int? Damage { get; set; }

        public int? Damage1 { get; set; }

        public int? Damage2 { get; set; }

        public int? AbilityPower { get; set; }

        public int? ManaStart { get; set; }

        public int? ManaMax { get; set; }

        public int? Armor { get; set; }

        public int? MagicResist { get; set; }

        public int? Range { get; set; }

        public string? Characterimageblob { get; set; }

        
    }
}
