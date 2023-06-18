using System;
using System.Collections.Generic;

namespace be.Models;

public partial class DefectOrigin
{
    public int DefectOriginId { get; set; }

    public string? DefectOriginName { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
