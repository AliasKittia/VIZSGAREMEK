using System;
using System.Collections.Generic;

namespace tftwebapinew.Models;

public partial class Board
{
    public int BoardId { get; set; }

    public int Id { get; set; }

    public string Boardname { get; set; } = null!;

    public int PostUserId { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
