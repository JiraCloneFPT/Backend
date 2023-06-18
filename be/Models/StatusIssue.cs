using System;
using System.Collections.Generic;

namespace be.Models;

public partial class StatusIssue
{
    public int StatusIssueId { get; set; }

    public string? StatusIssueName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();

    public virtual ICollection<Resolution> Resolutions { get; set; } = new List<Resolution>();
}
