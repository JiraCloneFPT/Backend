using be.DTOs;
using be.Models;

namespace be.Helpers
{
    public class HandleData
    {
        private readonly DbJiraCloneContext _context;
        public HandleData()
        {
            _context = new DbJiraCloneContext();
        }
        public IssueDTO HandleDataIssue(IssueDTO issue)
        {
            issue.ProjectName = _context.Projects.Where(x => x.ProjectId == issue.ProjectId).Select(x => x.ProjectName).FirstOrDefault();
            issue.IssueTypeName = _context.IssueTypes.Where(x => x.IssueTypeId == issue.IssueTypeId).Select(x => x.IssueTypeName).FirstOrDefault();
            issue.StatusIssueName = _context.StatusIssues.Where(x => x.StatusIssueId == issue.StatusIssueId).Select(x => x.StatusIssueName).FirstOrDefault();
            issue.PriorityName = _context.Priorities.Where(x => x.PriorityId == issue.PriorityId).Select(x => x.PriorityName).FirstOrDefault();
            issue.AssigneeName = _context.Users.Where(x => x.UserId == issue.AssigneeId).Select(x => x.FullName).FirstOrDefault();
            issue.ReporterName = _context.Users.Where(x => x.UserId == issue.ReporterId).Select(x => x.FullName).FirstOrDefault();
            issue.QcactivityName = _context.Users.Where(x => x.UserId == issue.QcactivityId).Select(x => x.FullName).FirstOrDefault();
            issue.ComponentName = _context.Components.Where(x => x.ComponentId == issue.ComponentId).Select(x => x.ComponentName).FirstOrDefault();
            issue.ProductName = _context.Products.Where(x => x.ProductId == issue.ProductId).Select(x => x.ProductName).FirstOrDefault();
            issue.DefectOriginName = _context.DefectOrigins.Where(x => x.DefectOriginId == issue.DefectOriginId).Select(x => x.DefectOriginName).FirstOrDefault();
            issue.DefectTypeName = _context.DefectTypes.Where(x => x.DefectTypeId == issue.DefectTypeId).Select(x => x.DefectTypeName).FirstOrDefault();
            issue.CauseCategoryName = _context.CauseCategories.Where(x => x.CauseCategoryId == issue.CauseCategoryId).Select(x => x.CauseCategoryName).FirstOrDefault();
            issue.TechnicalCauseName = _context.TechnicalCauses.Where(x => x.TechnicalCauseId == issue.TechnicalCauseId).Select(x => x.TechnicalCauseName).FirstOrDefault();
            issue.RoleIssueName = _context.RoleIssues.Where(x => x.RoleIssueId == issue.RoleIssueId).Select(x => x.RoleIssueName).FirstOrDefault();
            issue.LeakCauseName = _context.LeakCauses.Where(x => x.LeakCauseId == issue.LeakCauseId).Select(x => x.LeakCauseName).FirstOrDefault();
            issue.ShortNameProject = _context.Projects.Where(x => x.ProjectId == issue.ProjectId).Select(x => x.ShortName).FirstOrDefault();

            return issue;
        }
        public HistoryDTO HandleDataHistory(HistoryDTO history)
        {
            history.EditorName = _context.Users.Where(x => x.UserId == history.EditorId).Select(x => x.FullName).FirstOrDefault();
            history.Project = _context.Projects.Where(x => x.ProjectId == history.ProjectId).Select(x => x.ProjectName).FirstOrDefault();
            history.IssueType = _context.IssueTypes.Where(x => x.IssueTypeId == history.IssueTypeId).Select(x => x.IssueTypeName).FirstOrDefault();
            history.StatusIssue = _context.StatusIssues.Where(x => x.StatusIssueId == history.StatusIssueId).Select(x => x.StatusIssueName).FirstOrDefault();
            history.Priority = _context.Priorities.Where(x => x.PriorityId == history.PriorityId).Select(x => x.PriorityName).FirstOrDefault();
            history.Assignee = _context.Users.Where(x => x.UserId == history.AssigneeId).Select(x => x.FullName).FirstOrDefault();
            history.Reporter = _context.Users.Where(x => x.UserId == history.ReporterId).Select(x => x.FullName).FirstOrDefault();
            history.QCActivity = _context.Users.Where(x => x.UserId == history.QcactivityId).Select(x => x.FullName).FirstOrDefault();
            history.Component = _context.Components.Where(x => x.ComponentId == history.ComponentId).Select(x => x.ComponentName).FirstOrDefault();
            history.Product = _context.Products.Where(x => x.ProductId == history.ProductId).Select(x => x.ProductName).FirstOrDefault();
            history.DefectOrigin = _context.DefectOrigins.Where(x => x.DefectOriginId == history.DefectOriginId).Select(x => x.DefectOriginName).FirstOrDefault();
            history.DefectType = _context.DefectTypes.Where(x => x.DefectTypeId == history.DefectTypeId).Select(x => x.DefectTypeName).FirstOrDefault();
            history.CauseCategory = _context.CauseCategories.Where(x => x.CauseCategoryId == history.CauseCategoryId).Select(x => x.CauseCategoryName).FirstOrDefault();
            history.TechnicalCause = _context.TechnicalCauses.Where(x => x.TechnicalCauseId == history.TechnicalCauseId).Select(x => x.TechnicalCauseName).FirstOrDefault();
            history.RoleIssue = _context.RoleIssues.Where(x => x.RoleIssueId == history.RoleIssueId).Select(x => x.RoleIssueName).FirstOrDefault();
            history.LeakCause = _context.LeakCauses.Where(x => x.LeakCauseId == history.LeakCauseId).Select(x => x.LeakCauseName).FirstOrDefault();
            history.ShortNameProject = _context.Projects.Where(x => x.ProjectId == history.ProjectId).Select(x => x.ShortName).FirstOrDefault();

            return history;
        }
    }
}
