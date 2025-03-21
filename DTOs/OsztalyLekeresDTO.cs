namespace ProjectName_Backend.DTOs
{
    public class OsztalyLekeresDTO
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; } = null!;
        public string? BasicEffect { get; set; }
        public byte[]? Classimageblob { get; set; }

        public int Level { get; set; }
        public int? CharacterCount { get; set; }
        public string? BonusEffect { get; set; }
    }

   
}
