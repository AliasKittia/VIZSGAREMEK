namespace ProjectName_Backend.DTOs
{
    public class OsztalyLekeresDTO
    {
        public int ClassId { get; set; }

        public string ClassName { get; set; } = null!;

        public string? BasicEffect { get; set; }

        public string? Classimageblob { get; set; }
        public int Level { get; set; }
        public int? CharacterCount { get; set; }
        public string? BonusEffect { get; set; }
    }
}
