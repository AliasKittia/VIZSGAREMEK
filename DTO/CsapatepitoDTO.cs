using System.Text.Json.Serialization;
using tftwebapinew.Models;

namespace tftwebapinew.DTO
{
    public class CsapatepitoBoardHexDTO
    {
        public required int Id { get; set; }
        public required int Board_id { get; set; }
        public required int CharacterID { get; set; }
        public required int hex_x { get; set; }
        public required int hex_y { get; set; }
    }
    public class CsapatepitoBoardDTO
    {
        public int Board_id { get; set; }
        public int id { get; set; }
        public string? Boardname { get; set; }
        public int PostUserId { get; set; }

        [JsonIgnore]
        public virtual PostUser? PostUser { get; set; }
    }
    public class CsapatepitoOsztalyDTO
    {
        public required int ClassId { get; set; }
        public required string ClassName { get; set; }
        public required string BasicEffect { get; set; }

        public virtual ICollection<PostClassLevelBonus> Classlevelbonus { get; set; } = new List<PostClassLevelBonus>();

        public virtual ICollection<PostCharacter> Characters { get; set; } = new List<PostCharacter>();
    }

    public class CsapatepitoCharacterDTO
    {
        public required int CharacterID { get; set; }
        public required string CharacterName { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostBoardHex> BoardHexes { get; set; } = new List<PostBoardHex>();
        public virtual ICollection<PostClass> Classes { get; set; } = new List<PostClass>();
    }

    public class CsapatepitoUserDTO
    {
        [JsonIgnore]
        public virtual ICollection<PostBoard> Boards { get; set; } = new List<PostBoard>();
        [JsonIgnore]
        public virtual PostPermission Permission { get; set; } = null!;
    }
}
