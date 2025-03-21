namespace tftwebapi.Models{
public partial class PostBoardHex
{
    public int Id { get; set; }

    public int BoardId { get; set; }

    public int CharacterId { get; set; }

    public int HexX { get; set; }

    public int HexY { get; set; }

    public virtual PostCharacter Character { get; set; } = null!;
}
}

