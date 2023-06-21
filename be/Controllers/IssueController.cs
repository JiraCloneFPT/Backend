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
        private readonly IExportService _issueService;
        private readonly DbJiraCloneContext _context;
<<<<<<< HEAD
        private readonly IUserService _userService;
      
        public IssueController(DbJiraCloneContext db, IIssueService issueService)
=======
        public IssueController(DbJiraCloneContext db, IExportService issueService)
>>>>>>> 85de41de62cae4439895b8140225f10fa50b5b7f
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
        // Route get all issue by id user and id component
        [HttpGet("user")]
        public async Task<ActionResult> GetElementsByIdUser(int idUser, int idComponent)
        {
            try
            {
                return Ok(await _issueService.GetElementsByIdUser(idUser, idComponent));
            }
            catch
            {
                return BadRequest();
            }
        }
        // Route get issue by id
        [HttpGet]
        public async Task<ActionResult> GetElement(int id)
        {
            try
            {
                return Ok(await _issueService.GetElement(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        // Route get all issue
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

        //Phần của Huy
        [HttpGet("GetAllIsseByUserId")]
        public ActionResult GetAllIsseByUserId(int userId)
        {
            try
            {
                var issueList = _issueService.GetAllIssueByUserId(userId);
                return Ok(issueList);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
