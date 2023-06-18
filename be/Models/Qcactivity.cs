using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Qcactivity
{
    public int QcactivityId { get; set; }

    public string? QcactivityName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
