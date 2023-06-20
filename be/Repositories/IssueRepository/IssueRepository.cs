﻿using be.Commons;
using be.DTOs;
using be.Models;
using be.Repositories.BaseRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Component = be.Models.Component;

namespace be.Repositories.IssueRepository
{

    /// <summary>
    /// Issue Repository
    /// </summary> 
    public class ExportRepository : BaseRepository<Issue>, IExportRepository
    {
        public ExportRepository(DbJiraCloneContext context) : base(context)
        {
        }

        public async Task<bool> CreateIssue(IssueCreateDTO issue)
        {
            try
            {
                Issue newIssue = new Issue();
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
                newIssue.StatusIssueId = issue.StatusIssueId;
                newIssue.CreateTime = DateTime.Now;

                await context.Issues.AddAsync(newIssue);
                var created = await context.SaveChangesAsync();

                return created > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get Items to Create Issue
        public async Task<ListItemsToCreateIssueDTO> GetItemsCreateIssue()
        {
            var enumCommon = new EnumCommon();
            var result = new ListItemsToCreateIssueDTO()
            {
                Projects = context.Projects.Select(e => new Project { ProjectId = e.ProjectId, ProjectName = e.ProjectName }).ToList(),
                IssueTypes = context.IssueTypes.Select(e => new IssueType { IssueTypeId = e.IssueTypeId, IssueTypeName = e.IssueTypeName }).ToList(),
                Components = context.Components.Select(e => new Component { ComponentId = e.ComponentId, ComponentName = e.ComponentName }).ToList(),
                Products = context.Products.Select(e => new Product { ProductId = e.ProductId, ProductName = e.ProductName }).ToList(),
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
                // not match // Maybe match with Issue1 in model 
                LinkedIssues = enumCommon.LinkedIssues,
                Issues = context.Issues.Select(e => new Issue { IssueId = e.IssueId, Summary = e.Summary }).Take(10).ToList(),
                EpicLinks = enumCommon.EpicLinks,
                SecurityLevels = enumCommon.SecurityLevels,
                DefectTypes = context.DefectTypes.Select(e => new DefectType { DefectTypeId = e.DefectTypeId, DefectTypeName = e.DefectTypeName }).Take(10).ToList(),
                CauseCategories = context.CauseCategories.Select(e => new CauseCategory { CauseCategoryId = e.CauseCategoryId, CauseCategoryName = e.CauseCategoryName }).ToList(),
                LeakCauses = context.LeakCauses.Select(e => new LeakCause { LeakCauseId = e.LeakCauseId, LeakCauseName = e.LeakCauseName }).ToList(),

            };
            return result;
        }
        //Get items Issue by id
        public async Task<Object> GetElement(int id)
        {
            var data = await context.Issues.Where(x => x.IssueId == id).Select(issue => new
            {
                issue.IssueId,
                issue.ProjectId,
                projecyName = context.Projects.Where(x => x.ProjectId == issue.ProjectId).FirstOrDefault().ProjectName,
                issue.IssueType,
                issueTypeName = context.IssueTypes.Where(x => x.IssueTypeId == issue.IssueTypeId).FirstOrDefault().IssueTypeName,
                issue.ComponentId,
                componentName = context.Components.Where(x => x.ComponentId == issue.ComponentId).FirstOrDefault().ComponentName,
                issue.ProductId,
                productName = context.Products.Where(x => x.ProductId == issue.ProductId).FirstOrDefault().ProductName,
                issue.ReporterId,
                reporterName = context.Users.Where(x => x.UserId == issue.ReporterId).FirstOrDefault().FullName,
                issue.AssigneeId,
                assigneeName = context.Users.Where(x => x.UserId == issue.AssigneeId).FirstOrDefault().FullName,
                issue.Summary,
                issue.Description,
                issue.DefectOriginId,
                defectOriginName = context.DefectOrigins.Where(x => x.DefectOriginId == issue.DefectOriginId).FirstOrDefault().DefectOriginName,
                issue.PriorityId,
                priorityName = context.Priorities.Where(x => x.PriorityId == issue.PriorityId).FirstOrDefault().PriorityName,
                issue.QcactivityId,
                qcActivityName = context.Qcactivities.Where(x => x.QcactivityId == issue.QcactivityId).FirstOrDefault().QcactivityName,
                issue.RoleIssueId,
                roleIssueName = context.RoleIssues.Where(x => x.RoleIssueId == issue.RoleIssueId).FirstOrDefault().RoleIssueName,
                issue.DefectTypeId,
                defectypeName = context.DefectTypes.Where(x => x.DefectTypeId == issue.DefectTypeId).FirstOrDefault().DefectTypeName,
                issue.CauseCategoryId,
                causeCategoryName = context.CauseCategories.Where(x => x.CauseCategoryId == issue.CauseCategoryId).FirstOrDefault().CauseCategoryName,
                issue.LeakCauseId,
                leakCauseName = context.LeakCauses.Where(x => x.LeakCauseId == issue.LeakCauseId).FirstOrDefault().LeakCauseName,
                issue.StatusIssueId,
                statusIssueName = context.StatusIssues.Where(x => x.StatusIssueId == issue.StatusIssueId).FirstOrDefault().StatusIssueName,
                issue.SecurityLevel,
                issue.Labels,
                issue.CreateTime
            }).FirstOrDefaultAsync();
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

        //Get items Issue by idUser 
        public async Task<Object> GetElementsByIdUser(int idUser, int idComponent)
        {
            var result = idComponent == -1 ? (from i in context.Issues
                                              where i.ReporterId == idUser
                                              join u in context.Users on i.Assignee.UserId equals u.UserId
                                              join it in context.IssueTypes on i.IssueType.IssueTypeId equals it.IssueTypeId
                                              select new
                                              {
                                                  i.IssueId,
                                                  u.FullName,
                                                  i.Summary,
                                                  it.IssueTypeImage,
                                                  i.ComponentId
                                              }).ToList() : (from i in context.Issues
                                                             where i.ReporterId == idUser && i.ComponentId == idComponent
                                                             join u in context.Users on i.Assignee.UserId equals u.UserId
                                                             join it in context.IssueTypes on i.IssueType.IssueTypeId equals it.IssueTypeId
                                                             select new
                                                             {
                                                                 i.IssueId,
                                                                 u.FullName,
                                                                 i.Summary,
                                                                 it.IssueTypeImage,
                                                                 i.ComponentId
                                                             }).ToList();

            if (result == null)
            {
                return new
                {
                    status = 400
                };
            }
            return new
            {
                status = 200,
                data = result
            };
        }

        
    }


}
