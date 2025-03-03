using System;
using System.Collections.Generic;

namespace ProjectName_Backend.Models;

public partial class FullitemsPartialitem
{
    public int Id { get; set; }

    public int FullItemId { get; set; }

    public int PartialItemId1 { get; set; }

    public int PartialItemId2 { get; set; }

    public virtual Fullitem FullItem { get; set; } = null!;

    public virtual Partialitem PartialItemId1Navigation { get; set; } = null!;

    public virtual Partialitem PartialItemId2Navigation { get; set; } = null!;
}
