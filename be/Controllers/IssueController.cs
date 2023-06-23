using AutoMapper;
using be.DTOs;
using be.Helpers;
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
        private readonly Mapper mapper;
        private readonly HandleData handleData;
        private readonly DbJiraCloneContext _context;

        private readonly IUserService _userService;

        public IssueController(DbJiraCloneContext db, IIssueService issueService)
        {
            mapper = MapperConfig.InitializeAutomapper();
            _context = db;
            _issueService = issueService;
            handleData = new HandleData();
            _userService = new UserService();

        }

        // Edit Issue
        [HttpPost("edit")]
        public async Task<ActionResult> Edit([FromBody] IssueCreateDTO issue)
        {
            try
            {
                if (issue == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.EditIssue(issue);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        // Create Issue
        [HttpPost("addWithFile")]
        public async Task<ActionResult> addWithFile([FromForm] IssueCreateDTO issue)
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

        #region HIEUVM15

        [HttpGet("myopenissue")]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> MyOpenIssue(int idUser)
        {
            try
            {
                var result = await _issueService.MyOpenIssue(idUser);
                return Ok(result);
            }

            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("reportbyme")]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> ReportByMe(int idUser)
        {
            try
            {
                var result = await _issueService.ReportByMe(idUser);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("allissue")]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> AllIssue()
        {
            try
            {
                var result = await _issueService.AllIssue();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
