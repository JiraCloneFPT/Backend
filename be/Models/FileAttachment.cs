using System;
using System.Collections.Generic;

namespace be.Models;

public partial class FileAttachment
{
    public int FileAttachmentId { get; set; }

    public int IssueId { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public DateTime? Created { get; set; }

    public int? FileSize { get; set; }

    public virtual Issue Issue { get; set; } = null!;
}
