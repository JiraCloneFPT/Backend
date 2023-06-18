using System;
using System.Collections.Generic;

namespace be.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? IssueId { get; set; }

    public string? CommentContent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UserId { get; set; }

    public virtual Issue? Issue { get; set; }

    public virtual User? User { get; set; }
}
