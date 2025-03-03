using System;
using System.Collections.Generic;

namespace ProjectName_Backend.Models;

public partial class Anomaly
{
    public int AnomalyId { get; set; }

    public string? AnomalyName { get; set; }

    public string? AnomalyEffect { get; set; }
}
