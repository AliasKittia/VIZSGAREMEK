using System;
using System.Collections.Generic;

namespace tftwebapinew.Models;

public partial class Classlevelbonu
{
    public int ClassId { get; set; }

    public int Level { get; set; }

    public int? CharacterCount { get; set; }

    public string? BonusEffect { get; set; }

    public virtual Class Class { get; set; } = null!;
}
