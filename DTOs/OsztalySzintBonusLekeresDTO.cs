namespace ProjectName_Backend.DTOs
{
    public class OsztalySzintBonusLekeresDTO
    {
        public int ClassId { get; set; }
        public int Level { get; set; }
        public int? CharacterCount { get; set; }
        public string? BonusEffect { get; set; }

        
        public OsztalyLekeresDTO Class { get; set; } = null!;
    }
}
