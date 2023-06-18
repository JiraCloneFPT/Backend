using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Component
{
    public int ComponentId { get; set; }

    public string? ComponentName { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
