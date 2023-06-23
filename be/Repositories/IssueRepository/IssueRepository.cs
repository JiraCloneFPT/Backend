using AutoMapper;
using be.Commons;
using be.DTOs;
using be.Helpers;
using be.Models;
using be.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Component = be.Models.Component;


namespace be.Repositories.IssueRepository
{

    /// <summary>
    /// Issue Repository
    /// </summary> 
    public class IssueRepository : BaseRepository<Issue>, IIssueRepository
    {
        private readonly HandleData handleData;
        private readonly Mapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IssueRepository(DbJiraCloneContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _webHostEnvironment = webHostEnvironment;
            mapper = MapperConfig.InitializeAutomapper();
            handleData = new HandleData();

        }

        public async Task<History> CreateHistoryIssue(Issue issue, int userId)
        {
            try
            {
                History history = new History();
                var dateTime = DateTime.Now;
                history.EditorId = userId;
                history.ProjectId = issue.ProjectId;
                history.IssueTypeId = issue.IssueTypeId;
                history.ComponentId = issue.ComponentId;
                history.ProductId = issue.ProductId;
                history.ReporterId = issue.ReporterId;
                history.AssigneeId = issue.AssigneeId;
                history.Summary = issue.Summary;
                history.Description = issue.Description;
                history.DescriptionTranslate = issue.DescriptionTranslate;
                history.FixVersion = issue.FixVersion;
                history.DefectOriginId = issue.DefectTypeId;
                history.PriorityId = issue.PriorityId;
                history.Severity = issue.Severity;
                history.QcactivityId = issue.QcactivityId;
                history.AffectsVersion = issue.AffectsVersion;
                history.CauseAnalysis = issue.CauseAnalysis;
                history.CauseAnalysisTranslate = issue.CauseAnalysisTranslate;
                history.TechnicalCauseId = issue.TechnicalCauseId;
                history.Environment = issue.Environment;
                history.RoleIssueId = issue.RoleIssueId;
                history.PlannedStart = issue.PlannedStart;
                history.OriginalEstimate = issue.OriginalEstimate;
                history.RemainingEstimate = issue.RemaningEstimate;
                history.EstimateEffort = issue.EstimateEffort;
                history.Complexity = issue.Complexity;
                history.AdjustVp = issue.AdjustedVp;
                history.ValuePoint = issue.ValuePoint;
                history.DueDate = issue.DueDate;
                history.Labels = issue.Labels;
                history.Sprint = issue.Sprint;
                history.FunctionId = issue.FunctionId;
                history.TestcaseId = issue.TestcaseId;
                history.FunctionCategory = issue.FunctionCategory;
                //newIssue.LinkedIssueId // not match in db 
                history.Issue = issue.Issue1;   // issue 
                history.EpicLink = issue.EpicLink;
                history.ClosedDate = issue.ClosedDate;
                history.SecurityLevel = issue.SecurityLevel;
                history.DefectTypeId = issue.DefectTypeId;
                history.CauseCategoryId = issue.CauseCategoryId;
                history.LeakCauseId = issue.LeakCauseId;
                history.DueTime = issue.DueTime;
                history.Units = issue.Units;
                history.PercentDone = issue.PercentDone;
                history.StatusIssueId = ((int)Commons.StatusIssue.Open);
                history.CreateTime = dateTime;

                await context.Histories.AddAsync(history);
                await context.SaveChangesAsync();

                var lastHistory = context.Histories.Where(e => e.CreateTime == dateTime).FirstOrDefault();

                return lastHistory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    issueEdit.Summary = issue?.Summary;
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
                    issueEdit.Labels = issue.Labels;
                    issueEdit.Sprint = issue.Sprint;
                    issueEdit.FunctionId = issue.FunctionId;
                    issueEdit.TestcaseId = issue.TestcaseId;
                    issueEdit.FunctionCategory = issue.FunctionCategory;
                    //issueEdit.LinkedIssueId  // field not have in db 
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
                    issueEdit.Resolution = issue.Resolution; // 
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
                newIssue.ProductId = issue.ProductId;
                newIssue.ReporterId = issue.ReporterId;
                newIssue.AssigneeId = issue.AssigneeId;
                newIssue.Summary = issue.Summary;
                newIssue.Description = issue.Description;
                newIssue.DescriptionTranslate = issue.DescriptionTranslate;
                newIssue.FixVersion = issue.FixVersion;
                newIssue.DefectOriginId = issue.DefectTypeId;
                newIssue.PriorityId = issue.PriorityId;
                newIssue.Severity = issue.Severity;
                newIssue.QcactivityId = issue.QcactivityId;
                newIssue.AffectsVersion = issue.AffectsVersion;
                newIssue.CauseAnalysis = issue.CauseAnalysis;
                newIssue.CauseAnalysisTranslate = issue.CauseAnalysisTranslate;
                newIssue.TechnicalCauseId = issue.TechnicalCauseId;
                newIssue.Environment = issue.Environment;
                newIssue.RoleIssueId = issue.RoleIssueId;
                newIssue.PlannedStart = issue.PlannedStart;
                newIssue.OriginalEstimate = issue.OriginalEstimate;
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
                newIssue.StatusIssueId = ((int)Commons.StatusIssue.Open);
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
                Projects = context.Projects.Where(e=>e.Status == true).Select(e => new Project { ProjectId = e.ProjectId, ProjectName = e.ProjectName }).ToList(),
                IssueTypes = context.IssueTypes.Select(e => new IssueType { IssueTypeId = e.IssueTypeId, IssueTypeName = e.IssueTypeName }).ToList(),
                Components = context.Components.Where(e=>e.Status == true).Select(e => new Component { ComponentId = e.ComponentId, ComponentName = e.ComponentName }).ToList(),
                Products = context.Products.Where(e=>e.Status == true).Select(e => new Product { ProductId = e.ProductId, ProductName = e.ProductName }).ToList(),
                DefectOrigins = context.DefectOrigins.Select(e => new DefectOrigin { DefectOriginId = e.DefectOriginId, DefectOriginName = e.DefectOriginName }).ToList(),
                Priorities = context.Priorities.ToList(),
                Severities = enumCommon.Severitys,
                QCActivities = context.Qcactivities.Select(e => new Qcactivity { QcactivityId = e.QcactivityId, QcactivityName = e.QcactivityName }).Take(10).ToList(),
                TechnicalCauses = context.TechnicalCauses.Select(e => new TechnicalCause { TechnicalCauseId = e.TechnicalCauseId, TechnicalCauseName = e.TechnicalCauseName }).Take(10).ToList(),
                Assignees = context.Users.Select(e => new User { UserId = e.UserId, AccountName = e.AccountName }).ToList(),
                Roles = context.RoleUsers.Select(e => new RoleUser { RoleId = e.RoleId, RoleName = e.RoleName }).ToList(),
                Reporters = context.Users.Select(e => new User { UserId = e.UserId, AccountName = e.AccountName }).ToList(),
                Complexities = enumCommon.Complexities,
                Labels = enumCommon.Labels,
                Sprints = enumCommon.Sprints,
                FunctionCategories = enumCommon.FunctionCategories,
                LinkedIssues = enumCommon.LinkedIssues,
                //Issues = context.Issues.Select(e => new Issue { IssueId = e.IssueId, Summary = e.Summary }).Take(10).ToList(),
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
        //Get items Issue by id
        public async Task<Object> GetElement(int id)
        {
            var data = await context.Issues.Where(x => x.IssueId == id).Select(x => handleData.HandleDataIssue(mapper.Map<IssueDTO>(x))).FirstOrDefaultAsync();
            if (data == null)
            {
                return new
                {
                    status = 400,
                    message = "The issue doesn't exist in database"
                };
            }
            return new
            {
                status = 200,
                data,
                message = "Get issue is success!"
            };
        }


        public async Task<object> MyOpenIssue(int idUser)
        {
            var statustype = await context.StatusIssues.Where(x => x.StatusIssueName.Equals("Open")).FirstOrDefaultAsync();
            var data = await context.Issues.Where(x => x.AssigneeId == idUser || x.ReporterId == idUser).Where(x => x.StatusIssueId == statustype.StatusIssueId).OrderByDescending(x => x.CreateTime).Select(x => handleData.HandleDataIssue(mapper.Map<IssueDTO>(x))).ToListAsync();
            return new
            {
                status = 200,
                data
            };
        }
        public async Task<object> ReportByMe(int idUser)
        {
            var data = await context.Issues.Where(x => x.ReporterId == idUser).OrderByDescending(x => x.CreateTime).Select(x => handleData.HandleDataIssue(mapper.Map<IssueDTO>(x))).ToListAsync();
            return new
            {
                status = 200,
                data
            };
        }
        public async Task<object> AllIssue()
        {
            var data = await context.Issues.OrderByDescending(x => x.CreateTime).Select(x => handleData.HandleDataIssue(mapper.Map<IssueDTO>(x))).ToListAsync();
            return new
            {
                status = 200,
                data
            };
        }
        
        
        
        public IList<ShortDesIssue> GetAllIssueByUserId(int userId)
        {

            var issueList = context.Issues.Where(x => x.AssigneeId == userId && (x.StatusIssueId == 1 || x.StatusIssueId == 2 || x.StatusIssueId == 5)).Take(50).OrderByDescending(x => x.IssueId).ToList();
            var result = (from i in issueList
                            join p in context.Projects
                            on i.ProjectId equals p.ProjectId
                            select new ShortDesIssue
                            {
                                IssueId = i.IssueId,
                                Key = p.ShortName + "-" + i.IssueId,
                                Sumary = i.Summary,
                                ReportId = i.ReporterId,
                                IssueType = i.IssueTypeId,
                            }).Take(50).ToList();
            return result;
        }

    }

}
