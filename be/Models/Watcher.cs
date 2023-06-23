using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Watcher
{
    public int WatcherId { get; set; }

    public int IssueId { get; set; }

    public int UserId { get; set; }

    public virtual Issue Issue { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
