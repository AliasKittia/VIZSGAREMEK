using System;
using System.Collections.Generic;

namespace tftwebapinew.Models;

public partial class Partialitem
{
    public int PartialItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Effect { get; set; }

    public string? HalfItemimageblob { get; set; }

    public virtual ICollection<FullitemsPartialitem> FullitemsPartialitemPartialItemId1Navigations { get; set; } = new List<FullitemsPartialitem>();

    public virtual ICollection<FullitemsPartialitem> FullitemsPartialitemPartialItemId2Navigations { get; set; } = new List<FullitemsPartialitem>();
}
