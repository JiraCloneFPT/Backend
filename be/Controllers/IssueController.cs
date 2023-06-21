using be.DTOs;
using be.Models;
using be.Services.IssueService;
using be.Services.OtherService;
using be.Services.UserService;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace be.Controllers
{
    /// <summary>
    /// Issue Controller
    /// </summary>
    [Route("api/issue")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly DbJiraCloneContext _context;
        private readonly IUserService _userService;
      
        public IssueController(DbJiraCloneContext db, IIssueService issueService)
        {
            _context = db;
            _issueService = issueService;
            _userService = new UserService();
           
        }

        // Get issue by id 
        [HttpGet("GetIssueById")]
        public async Task<IActionResult> GetIssueById(int id)
        {
            try
            {
                var resData = await _issueService.GetIssueById(id);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Create Issue
        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] IssueCreateDTO issue)
        {
            try
            {
                if (issue == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.CreateIssue(issue);
                
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get Items select list to Create Issue 
        [HttpGet("GetItemsIssue")]
        public async Task<IActionResult> GetItemsIssue()
        {
            try
            {
                var resData = await _issueService.GetItemsIssue();
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("report")]
        public ActionResult GetDataReportedByMe(int idUser)
        {
            var result = (from i in _context.Issues
                          where i.ReporterId == idUser
                          join u in _context.Users on i.Assignee.UserId equals u.UserId
                          join it in _context.IssueTypes on i.IssueType.IssueTypeId equals it.IssueTypeId
                          select new
                          {
                              i.IssueId,
                              u.FullName,
                              i.Summary,
                              it.IssueTypeImage,
                          }).ToList();

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                status = 200,
                data = result
            });
        }

        [HttpGet]
        public async Task<ActionResult> GetElement(int id)
        {
            try
            {
                var data = await _context.Issues.Where(x => x.IssueId == id).Select(issue => new
                {
                    issue.IssueId,
                    issue.ProjectId,
                    projecyName = _context.Projects.Where(x => x.ProjectId == issue.ProjectId).FirstOrDefault().ProjectName,
                    issue.IssueType,
                    issueTypeName = _context.IssueTypes.Where(x => x.IssueTypeId == issue.IssueTypeId).FirstOrDefault().IssueTypeName,
                    issue.ComponentId,
                    componentName = _context.Components.Where(x => x.ComponentId == issue.ComponentId).FirstOrDefault().ComponentName,
                    issue.ProductId,
                    productName = _context.Products.Where(x => x.ProductId == issue.ProductId).FirstOrDefault().ProductName,
                    issue.ReporterId,
                    reporterName = _context.Users.Where(x => x.UserId == issue.ReporterId).FirstOrDefault().FullName,
                    issue.AssigneeId,
                    assigneeName = _context.Users.Where(x => x.UserId == issue.AssigneeId).FirstOrDefault().FullName,
                    issue.Summary,
                    issue.Description,
                    issue.DefectOriginId,
                    defectOriginName = _context.DefectOrigins.Where(x => x.DefectOriginId == issue.DefectOriginId).FirstOrDefault().DefectOriginName,
                    issue.PriorityId,
                    priorityName = _context.Priorities.Where(x => x.PriorityId == issue.PriorityId).FirstOrDefault().PriorityName,
                    issue.QcactivityId,
                    qcActivityName = _context.Qcactivities.Where(x => x.QcactivityId == issue.QcactivityId).FirstOrDefault().QcactivityName,
                    issue.RoleIssueId,
                    roleIssueName = _context.RoleIssues.Where(x => x.RoleIssueId == issue.RoleIssueId).FirstOrDefault().RoleIssueName,
                    issue.DefectTypeId,
                    defectypeName = _context.DefectTypes.Where(x => x.DefectTypeId == issue.DefectTypeId).FirstOrDefault().DefectTypeName,
                    issue.CauseCategoryId,
                    causeCategoryName = _context.CauseCategories.Where(x => x.CauseCategoryId == issue.CauseCategoryId).FirstOrDefault().CauseCategoryName,
                    issue.LeakCauseId,
                    leakCauseName = _context.LeakCauses.Where(x => x.LeakCauseId == issue.LeakCauseId).FirstOrDefault().LeakCauseName,
                    issue.StatusIssueId,
                    statusIssueName = _context.StatusIssues.Where(x => x.StatusIssueId == issue.StatusIssueId).FirstOrDefault().StatusIssueName,
                    issue.SecurityLevel,
                    issue.Labels,                    
                }).FirstOrDefaultAsync();
                if (data == null)
                {
                    return Ok(new
                    {
                        status = 400,
                        message = "The issue doesn't exist in database"
                    });
                }
                return Ok(new
                {
                    status = 200,
                    data,
                    message = "Get issue is success!"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("all")]
        public async Task<ActionResult> GetElements()
        {
            try
            {
                var data = await _context.Issues.ToListAsync();
                return Ok(new
                {
                    status = 200,
                    data
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]

        public async Task<ActionResult> Edit([FromBody] Issue issue)
        {
            var element = await _context.Issues.FindAsync(issue.IssueId);
            if (element == null)
            {
                return Ok(new
                {
                    message = "The issue doesn't exist in database!",
                    status = 400
                });
            }
            _context.Entry(await _context.Issues.FirstOrDefaultAsync(x => x.IssueId == element.IssueId)).CurrentValues.SetValues(issue);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Edit issue success!",
                status = 200
            });
        }
        [HttpDelete("delete")]

        public async Task<ActionResult> Delete([FromBody] int id)
        {
            var element = await _context.Issues.FindAsync(id);
            if (element == null)
            {
                return Ok(new
                {
                    message = "The issue doesn't exist in database!",
                    status = 404
                });
            }
            try
            {
                _context.Issues.Remove(element);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "Delete issue success!",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    message = "Error system!",
                    status = 400,
                    data = e.Message
                });
            }
        }
    }
}
