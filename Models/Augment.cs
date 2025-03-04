using System;
using System.Collections.Generic;

namespace ProjectName_Backend.Models;

public partial class Augment
{
    public int AugmentId { get; set; }

    public string? AugmentName { get; set; }

    public string? AugmentRarity { get; set; }

    public string? AugmentEffect { get; set; }
}
