using System;
using System.Collections.Generic;

namespace be.Models;

public partial class CauseCategory
{
    public int CauseCategoryId { get; set; }

    public string? CauseCategoryName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
