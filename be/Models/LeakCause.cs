using System;
using System.Collections.Generic;

namespace be.Models;

public partial class LeakCause
{
    public int LeakCauseId { get; set; }

    public string? LeakCauseName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
