namespace ProjectName_Backend.DTOs
{
    public class OsztalyLekeresDTO
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; } = null!;
        public string? BasicEffect { get; set; }
        public string? Classimageblob { get; set; }

        // A bónuszok listája
        public List<ClasslevelbonuDTO> Classlevelbonus { get; set; } = new List<ClasslevelbonuDTO>();
    }

    // DTO a bónuszokhoz
    public class ClasslevelbonuDTO
    {
        public int Level { get; set; }
        public int? CharacterCount { get; set; }
        public string? BonusEffect { get; set; }
    }


}
