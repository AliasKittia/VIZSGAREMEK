using System;
using System.Collections.Generic;

namespace ProjectName_Backend.Models;

public partial class Board
{
    public int BoardId { get; set; }

    public int Id { get; set; }

    public string Boardname { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
