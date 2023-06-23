using System;
using System.Collections.Generic;

namespace be.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? Birthday { get; set; }

    public string? AccountName { get; set; }

    public string? Status { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Issue> IssueAssignees { get; set; } = new List<Issue>();

    public virtual ICollection<Issue> IssueReporters { get; set; } = new List<Issue>();

    public virtual RoleUser? Role { get; set; }

    public virtual ICollection<Watcher> Watchers { get; set; } = new List<Watcher>();
}
