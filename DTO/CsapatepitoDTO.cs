using System.Text.Json.Serialization;
using tftwebapinew.Models;

namespace tftwebapinew.DTO
{
    public class CsapatepitoOsztalyDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public string? BasicEffect { get; set; }

        public List<KarakterDTO> Karakterek { get; set; } = new List<KarakterDTO>();
    }

    public class CsapatepitoCharacterDTO
    {

        public int CharacterID { get; set; }
        public string CharacterName { get; set; } = null!;
        public string? Characterimageblob { get; set; }

        public List<HexCellDTO> hexCells { get; set; } = new List<HexCellDTO>();

        public List<OsztalyDTO> Osztalyok { get; set; } = new List<OsztalyDTO>();
    }

    public class CsapatepitoBoardHexDTO
    {
        public int Id { get; set; }
        public int Board_id { get; set; }
        public int hex_x { get; set; }
        public int hex_y { get; set; }
        public int? CharacterID { get; set; }
        public List<KarakterDTO> Karakterek { get; set; } = new List<KarakterDTO>();
        public List<PostBoard> Tablak { get; set; } = new List<PostBoard>();

    }

    public class CsapatepitoBoardDTO
    {
        public int Board_id { get; set; }
        public int id { get; set; }
        public string? Boardname { get; set; }
        public int PostUserId { get; set; }

        public List<HexCellDTO> hexCells { get; set; } = new List<HexCellDTO>();
        public List<PostUser> Felhasznalo { get; set; } = new List<PostUser>();
    }

    public class CsapatepitoUserDTO
    {
        public int Id { get; set; }
    }
}
