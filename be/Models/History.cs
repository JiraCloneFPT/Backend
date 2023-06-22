using System;
using System.Collections.Generic;

namespace be.Models;

public partial class History
{
    public int HistoryId { get; set; }

    public int? IssueId { get; set; }

    public int? ProjectId { get; set; }

    public int? IssueTypeId { get; set; }

    public int? ComponentId { get; set; }

    public int? ProductId { get; set; }

    public int? ReporterId { get; set; }

    public int? AssigneeId { get; set; }

    public string? Summary { get; set; }

    public string? Description { get; set; }

    public string? DescriptionTranslate { get; set; }

    public string? FixVersion { get; set; }

    public int? DefectOriginId { get; set; }

    public int? PriorityId { get; set; }

    public string? Severity { get; set; }

    public int? QcactivityId { get; set; }

    public string? AffectsVersion { get; set; }

    public string? CauseAnalysis { get; set; }

    public string? CauseAnalysisTranslate { get; set; }

    public string? CorrectAction { get; set; }

    public string? CorrectActionTranslate { get; set; }

    public int? TechnicalCauseId { get; set; }

    public string? Environment { get; set; }

    public int? RoleIssueId { get; set; }

    public DateTime? PlannedStart { get; set; }

    public string? OriginalEstimate { get; set; }

    public string? RemainingEstimate { get; set; }

    public string? EstimateEffort { get; set; }

    public int? Complexity { get; set; }

    public string? AdjustVp { get; set; }

    public string? ValuePoint { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Labels { get; set; }

    public string? Sprint { get; set; }

    public string? FunctionId { get; set; }

    public string? TestcaseId { get; set; }

    public string? FunctionCategory { get; set; }

    public string? Issue { get; set; }

    public string? EpicLink { get; set; }

    public DateTime? ClosedDate { get; set; }

    public string? SecurityLevel { get; set; }

    public int? DefectTypeId { get; set; }

    public int? CauseCategoryId { get; set; }

    public int? LeakCauseId { get; set; }

    public string? DueTime { get; set; }

    public string? Units { get; set; }

    public string? PercentDone { get; set; }

    public int? StatusIssueId { get; set; }

    public string? Resolution { get; set; }

    public DateTime CreateTime { get; set; }
}
