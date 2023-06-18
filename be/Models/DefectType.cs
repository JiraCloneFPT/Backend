using System;
using System.Collections.Generic;

namespace be.Models;

public partial class DefectType
{
    public int DefectTypeId { get; set; }

    public string? DefectTypeName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
