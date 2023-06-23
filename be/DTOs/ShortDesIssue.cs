namespace be.DTOs
{
    public class ShortDesIssue
    {
        public ShortDesIssue() { }
        public int IssueId { get; set; }
        public string Key { get; set; }
        public string Sumary { get; set; }
        public int? IssueType { get; set; }
        public int? ReportId { get; set; }
    }
}
