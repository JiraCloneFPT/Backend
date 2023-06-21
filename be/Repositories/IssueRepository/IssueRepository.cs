using be.Commons;
using be.DTOs;
using be.Models;
using be.Repositories.BaseRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace be.Repositories.IssueRepository
{

    /// <summary>
    /// Issue Repository
    /// </summary> 
    public class IssueRepository : BaseRepository<Issue>, IIssueRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IssueRepository(DbJiraCloneContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> AddFile(IFormFile file, Issue issue)
        {
            try
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/AttachFiles/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
                FileAttachment fileAttachment = new FileAttachment();
                fileAttachment.IssueId = issue.IssueId;
                fileAttachment.FileName = fileName;
                fileAttachment.FilePath = path;
                fileAttachment.Created = DateTime.Now;
                await context.FileAttachments.AddAsync(fileAttachment);
                var fileAdded = await context.SaveChangesAsync();
                return fileAdded > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Edit Issue
        public async Task<Issue> EditIssue(IssueCreateDTO issue)
        {
            try
            {
                var issueEdit = context.Issues.Where(e => e.IssueId == issue.IssueId).FirstOrDefault();
                if (issueEdit != null)
                {
                    issueEdit.Summary = issue.Summary;
                    issueEdit.ComponentId = issue.ComponentId;
                    issueEdit.ProductId = issue.ProductId;
                    issueEdit.Description = issue.Description;
                    issueEdit.DescriptionTranslate = issue.DescriptionTranslate;
                    issueEdit.DefectOriginId = issue.DefectTypeId;
                    issueEdit.PriorityId = issue.PriorityId;
                    issueEdit.Severity = issue.Severity;
                    issueEdit.QcactivityId = issue.QcactivityId;
                    issueEdit.CauseAnalysis = issue.CauseAnalysis;
                    issueEdit.CauseAnalysisTranslate = issue.CauseAnalysisTranslate;
                    issueEdit.CorrectAction = issue.CorrectAction;
                    issueEdit.CorrectActionTranslate = issue.CorrectActionTranslate;
                    issueEdit.TechnicalCauseId = issue.TechnicalCauseId;
                    issueEdit.Environment = issue.Environment;
                    issueEdit.AssigneeId = issue.AssigneeId;
                    issueEdit.RoleIssueId = issue.RoleIssueId;
                    issueEdit.ReporterId = issue.ReporterId;
                    issueEdit.PlannedStart = issue.PlannedStart;
                    issueEdit.OriginalEstimate = issue.OriginalEstimate;
                    issueEdit.RemaningEstimate = issue.RemainingEstimate;
                    issueEdit.EstimateEffort = issue.EstimateEffort;
                    issueEdit.Complexity = issue.Complexity;
                    issueEdit.AdjustedVp = issue.AdjustedVp;
                    issueEdit.DueDate = issue.DueDate;
                    //attach
                    issueEdit.Labels = issue.Labels;
                    issueEdit.Sprint = issue.Sprint;
                    issueEdit.FunctionId = issue.FunctionId;
                    issueEdit.TestcaseId = issue.TestcaseId;
                    issueEdit.FunctionCategory = issue.FunctionCategory;
                    //issueEdit.LinkedIssueId  // field is't have in db 
                    issueEdit.Issue1 = issue.Issue1;  // mockIssueId
                    issueEdit.EpicLink = issue.EpicLink;
                    issueEdit.ClosedDate = issue.ClosedDate;
                    issueEdit.SecurityLevel = issue.SecurityLevel;
                    issueEdit.DefectTypeId = issue.DefectTypeId;
                    issueEdit.CauseCategoryId = issue.CauseCategoryId;
                    issueEdit.LeakCauseId = issue.LeakCauseId;
                    issueEdit.DueTime = issue.DueTime;
                    issueEdit.Units = issue.Units;
                    issueEdit.PercentDone = issue.PercentDone;
                    //comment

                    context.Issues.Update(issueEdit);
                    var updated = await context.SaveChangesAsync();
                    return updated > 0 ? issueEdit : null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Create Issue
        public async Task<Issue> CreateIssue(IssueCreateDTO issue)
        {
            try
            {
                Issue newIssue = new Issue();
                var dateTime = DateTime.Now;

                newIssue.ProjectId = issue.ProjectId;
                newIssue.IssueTypeId = issue.IssueTypeId;
                newIssue.ComponentId = issue.ComponentId;
                newIssue.ProductId = issue.ProductId ;
                newIssue.ReporterId = issue.ReporterId ;
                newIssue.AssigneeId= issue.AssigneeId ;
                newIssue.Summary = issue.Summary ;
                newIssue.Description = issue.Description ;
                newIssue.DescriptionTranslate = issue.DescriptionTranslate ;
                newIssue.FixVersion = issue.FixVersion ;
                newIssue.DefectOriginId = issue.DefectTypeId ;
                newIssue.PriorityId = issue.PriorityId ;
                newIssue.Severity = issue.Severity ;
                newIssue.QcactivityId = issue.QcactivityId ;
                newIssue.AffectsVersion = issue.AffectsVersion ;
                newIssue.CauseAnalysis = issue.CauseAnalysis ;
                newIssue.CauseAnalysisTranslate = issue.CauseAnalysisTranslate ;
                newIssue.TechnicalCauseId = issue.TechnicalCauseId ;
                newIssue.Environment = issue.Environment ;
                newIssue.RoleIssueId = issue.RoleIssueId ;
                newIssue.PlannedStart = issue.PlannedStart ;
                newIssue.OriginalEstimate = issue.OriginalEstimate ;
                newIssue.RemaningEstimate = issue.RemainingEstimate;
                newIssue.EstimateEffort = issue.EstimateEffort;
                newIssue.Complexity = issue.Complexity;
                newIssue.AdjustedVp = issue.AdjustedVp;
                newIssue.ValuePoint = issue.ValuePoint;
                newIssue.DueDate = issue.DueDate;
                newIssue.Labels = issue.Labels;
                newIssue.Sprint = issue.Sprint;
                newIssue.FunctionId = issue.FunctionId;
                newIssue.TestcaseId = issue.TestcaseId;
                newIssue.FunctionCategory = issue.FunctionCategory;
                //newIssue.LinkedIssueId // not match in db 
                newIssue.Issue1 = issue.Issue1;
                newIssue.EpicLink = issue.EpicLink;
                newIssue.ClosedDate = issue.ClosedDate;
                newIssue.SecurityLevel = issue.SecurityLevel;
                newIssue.DefectTypeId = issue.DefectTypeId;
                newIssue.CauseCategoryId = issue.CauseCategoryId;
                newIssue.LeakCauseId = issue.LeakCauseId;
                newIssue.DueTime = issue.DueTime;
                newIssue.Units = issue.Units;
                newIssue.PercentDone = issue.PercentDone;
                newIssue.StatusIssueId = ((int)Commons.StatusIssue.Open) ; 
                newIssue.CreateTime = dateTime;

                await context.Issues.AddAsync(newIssue);
                await context.SaveChangesAsync();

                var lastIssue = context.Issues.Where(e=>e.CreateTime == dateTime).FirstOrDefault();

                return lastIssue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get Items to Create Issue
        public async Task<ListItemsOfIssueDTO> GetItemsIssue()
        {
            var enumCommon = new EnumCommon();
            var result = new ListItemsOfIssueDTO()
            {
                Projects = context.Projects.Where(e=>e.Status == 1).Select(e => new Project { ProjectId = e.ProjectId, ProjectName = e.ProjectName }).ToList(),
                IssueTypes = context.IssueTypes.Select(e => new IssueType { IssueTypeId = e.IssueTypeId, IssueTypeName = e.IssueTypeName }).ToList(),
                Components = context.Components.Where(e=>e.Status == 1).Select(e => new Component { ComponentId = e.ComponentId, ComponentName = e.ComponentName }).ToList(),
                Products = context.Products.Where(e=>e.Status == 1).Select(e => new Product { ProductId = e.ProductId, ProductName = e.ProductName }).ToList(),
                DefectOrigins = context.DefectOrigins.Select(e => new DefectOrigin { DefectOriginId = e.DefectOriginId, DefectOriginName = e.DefectOriginName }).ToList(),
                Priorities = context.Priorities.ToList(),
                Severities = enumCommon.Severitys,
                QCActivities = context.Qcactivities.Select(e => new Qcactivity { QcactivityId = e.QcactivityId, QcactivityName = e.QcactivityName }).Take(10).ToList(),
                TechnicalCauses = context.TechnicalCauses.Select(e => new TechnicalCause { TechnicalCauseId = e.TechnicalCauseId, TechnicalCauseName = e.TechnicalCauseName }).Take(10).ToList(),
                Assignees = context.Users.Select(e => new User { UserId = e.UserId, AccountName = e.AccountName }).ToList(),
                Roles = context.RoleUsers.Select(e => new RoleUser { RoleId = e.RoleId, RoleName = e.RoleName }).ToList(),
                Reporters = context.Users.Select(e => new User { UserId = e.UserId, AccountName = e.AccountName }).ToList(),
                Complexities = enumCommon.Complexities ,
                Labels = enumCommon.Labels,
                Sprints = enumCommon.Sprints,
                FunctionCategories = enumCommon.FunctionCategories,
                
                LinkedIssues = enumCommon.LinkedIssues, // not match // Maybe match with issue entity 
                Issues = context.Issues.Select(e => new Issue { IssueId = e.IssueId, Summary = e.Summary }).Take(10).ToList(),
                EpicLinks = enumCommon.EpicLinks,
                SecurityLevels = enumCommon.SecurityLevels,
                DefectTypes = context.DefectTypes.Select(e => new DefectType { DefectTypeId = e.DefectTypeId, DefectTypeName = e.DefectTypeName }).Take(10).ToList(),
                CauseCategories = context.CauseCategories.Select(e => new CauseCategory { CauseCategoryId = e.CauseCategoryId, CauseCategoryName = e.CauseCategoryName }).ToList(),
                LeakCauses = context.LeakCauses.Select(e => new LeakCause { LeakCauseId = e.LeakCauseId, LeakCauseName = e.LeakCauseName }).ToList(),

                ResolutionResolve = enumCommon.ResolutionResolve,
                ResolutionCancel = enumCommon.ResolutionCancel,
            };
            return result;
        }

    }


}
