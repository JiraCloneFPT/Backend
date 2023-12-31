﻿using AutoMapper;
using be.Commons;
using be.DTOs;
using be.Helpers;
using be.Models;
using be.Repositories.BaseRepository;
//using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Component = be.Models.Component;


namespace be.Repositories.IssueRepository
{

    /// <summary>
    /// Issue Repository
    /// </summary> 
    public class IssueRepository : BaseRepository<Models.Issue>, IIssueRepository
    {
        private readonly HandleData handleData;
        private readonly Mapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IssueRepository(DbJiraCloneContext context, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _webHostEnvironment = webHostEnvironment;
            mapper = MapperConfig.InitializeAutomapper();
            handleData = new HandleData();
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<CommentDTO>> GetComments(int issueId)
        {
            try
            {
                var result = (from c in context.Comments
                              join u in context.Users on c.UserId equals u.UserId
                              join i in context.Issues on c.IssueId equals i.IssueId
                              where c.IssueId == issueId
                              select new CommentDTO
                              {
                                  IssueId = c.IssueId,
                                  UserId = c.UserId,
                                  CommentContent = c.CommentContent,
                                  CreateAt = c.CreatedAt,
                                  FullName = u.FullName
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ChangeStatus(int userId, int issueId, int statusIssueId)
        {
            try
            {
                var issue = context.Issues.Where(e => e.IssueId.Equals(issueId)).FirstOrDefault();
                if(issue != null)
                {
                    issue.StatusIssueId = statusIssueId;
                    context.Issues.Update(issue);
                    var numUpdated = context.SaveChanges();
                    return numUpdated > 0 ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddComment(CommentDTO comment)
        {
            try
            {
                Models.Comment newComment = new Models.Comment();
                var dateTime = DateTime.Now;
                newComment.UserId = comment.UserId;
                newComment.IssueId = comment.IssueId;
                newComment.CommentContent = comment.CommentContent;
                newComment.CreatedAt = dateTime;
                context.Comments.Add(newComment);
                var numCommented = context.SaveChanges();
                return numCommented > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveFile(int fileId)
        {
            try
            {
                var file = context.FileAttachments.Where(e => e.FileAttachmentId.Equals(fileId)).FirstOrDefault();
                if (file != null)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath + "/AttachFiles/", file.FileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    context.FileAttachments.Remove(file);
                    var numRemoved = context.SaveChanges();
                    return numRemoved > 0 ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<object>> GetFilesIssue(int issueId)
        {
            try
            {
                var listFile = (from f in context.FileAttachments
                               join i in context.Issues on f.IssueId equals i.IssueId
                               where f.IssueId == issueId
                               select new FileAttachment
                               {
                                   FileAttachmentId = f.FileAttachmentId,
                                   FilePath = f.FilePath,
                                   FileName = f.FileName
                               }).ToList();

                List<object> fileList = new List<object>();

                foreach (var file in listFile)
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(file.FilePath);
                    string base64String = Convert.ToBase64String(fileBytes);

                    fileList.Add(new
                    {
                        Id = file.FileAttachmentId ,
                        Name = file.FileName,
                        Content = base64String,
                        fileSrc = String.Format("{0}://{1}{2}/AttachFiles/{3}", _httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host, _httpContextAccessor.HttpContext.Request.PathBase, file.FileName)
                    });
                }

                return fileList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    

        public async Task<History> CreateHistoryIssue(Models.Issue issue, int userId)
        {
            try
            {
                History history = new History();
                var dateTime = DateTime.Now;
                history.IssueId = issue.IssueId;
                history.EditorId = userId;
                history.IssueId = issue.IssueId;
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
                history.UpdateTime = dateTime;
                history.StatusIssueId = issue.StatusIssueId; //

                await context.Histories.AddAsync(history);
                await context.SaveChangesAsync();

                var lastHistory = context.Histories.Where(e => e.UpdateTime == dateTime).FirstOrDefault();

                return lastHistory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> AddFiles(List<IFormFile> files, Issue issue)
        {
            try
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                int numAdded = 0;
                foreach (var file in files)
                {
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
                    context.FileAttachments.Add(fileAttachment);
                    var fileAdded =  context.SaveChanges();
                    numAdded = fileAdded > 0 ? fileAdded : numAdded;
                }
                return numAdded > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddFile(IFormFile file, Models.Issue issue)
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
        public async Task<Models.Issue> EditIssue(IssueCreateDTO issue, int statusIssueId)
        {
            try
            {
                var issueEdit = context.Issues.Where(e => e.IssueId == issue.IssueId).FirstOrDefault();
                if (issueEdit != null)
                {
                    issueEdit.Summary = issue.Summary != null ? issue.Summary : issueEdit.Summary;
                    issueEdit.ComponentId = issue.ComponentId != null ? issue.ComponentId : issueEdit.ComponentId;
                    issueEdit.ProductId = issue.ProductId != null ? issue.ProductId : issueEdit.ProductId;
                    issueEdit.Description = issue.Description != null ? issue.Description : issueEdit.Description;
                    issueEdit.DescriptionTranslate = issue.DescriptionTranslate != null ? issue.DescriptionTranslate : issueEdit.DescriptionTranslate;
                    issueEdit.DefectOriginId = issue.DefectOriginId != null ? issue.DefectOriginId : issueEdit.DefectOriginId;
                    issueEdit.PriorityId = issue.PriorityId != null ? issue.PriorityId : issueEdit.PriorityId;
                    issueEdit.Severity = issue.Severity != null ? issue.Severity : issueEdit.Severity;
                    issueEdit.QcactivityId = issue.QcactivityId != null ? issue.QcactivityId : issueEdit.QcactivityId;
                    issueEdit.CauseAnalysis = issue.CauseAnalysis != null ? issue.CauseAnalysis : issueEdit.CauseAnalysis;
                    issueEdit.CauseAnalysisTranslate = issue.CauseAnalysisTranslate != null ? issue.CauseAnalysisTranslate : issueEdit.CauseAnalysisTranslate;
                    issueEdit.CorrectAction = issue.CorrectAction != null ? issue.CorrectAction : issueEdit.CorrectAction;
                    issueEdit.CorrectActionTranslate = issue.CorrectActionTranslate != null ? issue.CorrectActionTranslate : issueEdit.CorrectActionTranslate;
                    issueEdit.TechnicalCauseId = issue.TechnicalCauseId != null ? issue.TechnicalCauseId : issueEdit.TechnicalCauseId;
                    issueEdit.Environment = issue.Environment != null ? issue.Environment : issueEdit.Environment;
                    issueEdit.AssigneeId = issue.AssigneeId != null ? issue.AssigneeId : issueEdit.AssigneeId;
                    issueEdit.RoleIssueId = issue.RoleIssueId != null ? issue.RoleIssueId : issueEdit.RoleIssueId;
                    issueEdit.ReporterId = issue.ReporterId != null ? issue.ReporterId : issueEdit.ReporterId;
                    issueEdit.PlannedStart = issue.PlannedStart != null ? issue.PlannedStart : issueEdit.PlannedStart;
                    issueEdit.OriginalEstimate = issue.OriginalEstimate != null ? issue.OriginalEstimate : issueEdit.OriginalEstimate;
                    issueEdit.RemaningEstimate = issue.RemainingEstimate != null ? issue.RemainingEstimate : issueEdit.RemaningEstimate;
                    issueEdit.EstimateEffort = issue.EstimateEffort != null ? issue.EstimateEffort : issueEdit.EstimateEffort;
                    issueEdit.Complexity = issue.Complexity != null ? issue.Complexity : issueEdit.Complexity;
                    issueEdit.AdjustedVp = issue.AdjustedVp != null ? issue.AdjustedVp : issueEdit.AdjustedVp;
                    issueEdit.DueDate = issue.DueDate != null ? issue.DueDate : issueEdit.DueDate;
                    issueEdit.Labels = issue.Labels != null ? issue.Labels : issueEdit.Labels;
                    issueEdit.Sprint = issue.Sprint != null ? issue.Sprint : issueEdit.Sprint;
                    issueEdit.FunctionId = issue.FunctionId != null ? issue.FunctionId : issueEdit.FunctionId  ;
                    issueEdit.TestcaseId = issue.TestcaseId != null ? issue.TestcaseId : issueEdit.TestcaseId  ;
                    issueEdit.FunctionCategory = issue.FunctionCategory != null ? issue.FunctionCategory : issueEdit.FunctionCategory  ;
                    //issueEdit.LinkedIssueId  // field not have in db != null ? issue. : issueEdit.   
                    issueEdit.Issue1 = issue.Issue1 != null ? issue.Issue1 : issueEdit.Issue1; 
                    issueEdit.EpicLink = issue.EpicLink != null ? issue.EpicLink : issueEdit.EpicLink;
                    issueEdit.ClosedDate = issue.ClosedDate != null ? issue.ClosedDate : issueEdit.ClosedDate  ;
                    issueEdit.SecurityLevel = issue.SecurityLevel != null ? issue.SecurityLevel : issueEdit.SecurityLevel  ;
                    issueEdit.DefectTypeId = issue.DefectTypeId != null ? issue.DefectTypeId : issueEdit.DefectTypeId  ;
                    issueEdit.CauseCategoryId = issue.CauseCategoryId != null ? issue.CauseCategoryId : issueEdit.CauseCategoryId  ;
                    issueEdit.LeakCauseId = issue.LeakCauseId != null ? issue.LeakCauseId : issueEdit.LeakCauseId  ;
                    issueEdit.DueTime = issue.DueTime != null ? issue.DueTime : issueEdit.DueTime  ;
                    issueEdit.Units = issue.Units != null ? issue.Units : issueEdit.Units  ;
                    issueEdit.PercentDone = issue.PercentDone != null ? issue.PercentDone : issueEdit.PercentDone  ;
                    issueEdit.Resolution = issue.Resolution; // != null ? issue.Resolution : issueEdit.Resolution   
                    issueEdit.StatusIssueId = statusIssueId ;

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
        public async Task<Models.Issue> CreateIssue(IssueCreateDTO issue)
        {
            try
            {
                Models.Issue newIssue = new Models.Issue();
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
                QCActivities = context.Qcactivities.Select(e => new Qcactivity { QcactivityId = e.QcactivityId, QcactivityName = e.QcactivityName }).ToList(),
                TechnicalCauses = context.TechnicalCauses.Select(e => new TechnicalCause { TechnicalCauseId = e.TechnicalCauseId, TechnicalCauseName = e.TechnicalCauseName }).ToList(),
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
                DefectTypes = context.DefectTypes.Select(e => new DefectType { DefectTypeId = e.DefectTypeId, DefectTypeName = e.DefectTypeName }).ToList(),
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
