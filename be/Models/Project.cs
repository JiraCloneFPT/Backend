using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
