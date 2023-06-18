using System;
using System.Collections.Generic;

namespace be.Models;

public partial class RoleIssue
{
    public int RoleIssueId { get; set; }

    public string? RoleIssueName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
