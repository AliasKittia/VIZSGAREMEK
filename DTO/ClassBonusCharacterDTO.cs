namespace tftwebapinew.DTO
{
    public class ClassBonusCharacterDTO
    {
        public class ClassDto
        {
            public required string ClassName { get; set; }
            public required string Classimageblob { get; set; }
            public  byte[]? ClassImageBlob { get; internal set; }
            public required string BasicEffect { get; set; }
            public required List<ClassLevelBonusDto> LevelBonuses { get; set; }
            public required List<CharacterDto> Characters { get; set; }
        }

        public class ClassLevelBonusDto
        {
            public int Level { get; set; }
            public int CharacterCount { get; set; }
            public required string BonusEffect { get; set; }
        }

        public class CharacterDto
        {
            public required string  CharacterName { get; set; }
            public required byte[] Characterimageblob { get; set; } 
        }
    }
}