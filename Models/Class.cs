using System;
using System.Collections.Generic;

namespace ProjectName_Backend.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public string? BasicEffect { get; set; }

    public string? Classimageblob { get; set; }

    public virtual ICollection<Classlevelbonu> Classlevelbonus { get; set; } = new List<Classlevelbonu>();

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
