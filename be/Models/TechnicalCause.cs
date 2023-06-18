using System;
using System.Collections.Generic;

namespace be.Models;

public partial class TechnicalCause
{
    public int TechnicalCauseId { get; set; }

    public string? TechnicalCauseName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
