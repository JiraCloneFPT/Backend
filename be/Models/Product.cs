using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
