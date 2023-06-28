using be.Helpers;

namespace be.Models
{
    public class HistoryForEmail
    {
        public string ProjectName { get; set; }

        public string ProjectShortName { get; set; }

        public int IssueId { get; set; }

        public string StatusIssueName { get; set; }

        public string IssueSummary { get; set; }

        public string EditorName { get; set; }
        public List<Properties> Properties { get; set; }
        public DateTime CreateAt { get; set; }

        public string ReporterEmail { get; set; }

        public string AssigneeEmail { get; set;}
    }
}
