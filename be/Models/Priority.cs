using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Priority
{
    public int PriorityId { get; set; }

    public string? PriorityName { get; set; }

    public string? PriorityImage { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
