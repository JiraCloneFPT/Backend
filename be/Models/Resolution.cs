using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Resolution
{
    public int ResolutionId { get; set; }

    public string ResolutionContent { get; set; } = null!;

    public int StatusIssueId { get; set; }

    public virtual StatusIssue StatusIssue { get; set; } = null!;
}
