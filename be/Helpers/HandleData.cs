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
            return issue;
        } 
    }
}
