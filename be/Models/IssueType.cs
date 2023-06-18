using System;
using System.Collections.Generic;

namespace be.Models;

public partial class IssueType
{
    public int IssueTypeId { get; set; }

    public string? IssueTypeName { get; set; }

    public bool? Status { get; set; }

    public string? IssueTypeImage { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
