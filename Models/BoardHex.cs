using System;
using System.Collections.Generic;

namespace tftwebapinew.Models;

public partial class BoardHex
{
    public int Id { get; set; }

    public int BoardId { get; set; }

    public int CharacterId { get; set; }

    public int HexX { get; set; }

    public int HexY { get; set; }

    public virtual Character Character { get; set; } = null!;
}
