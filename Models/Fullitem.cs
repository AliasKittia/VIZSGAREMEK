using System;
using System.Collections.Generic;

namespace ProjectName_Backend.Models;

public partial class Fullitem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Halfitemeffect1 { get; set; }

    public string? Halfitemeffect2 { get; set; }

    public string? Bonuseffect { get; set; }

    public string? Bonuseffect1 { get; set; }

    public string? Bonuseffect2 { get; set; }

    public string? ActiveEffect { get; set; }

    public byte[]? Fullitemimageblob { get; set; }

    public virtual ICollection<FullitemsPartialitem> FullitemsPartialitems { get; set; } = new List<FullitemsPartialitem>();
}
