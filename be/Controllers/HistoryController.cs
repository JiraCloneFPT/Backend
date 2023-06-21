using be.DTOs;
using be.Models;
using be.Services.IssueService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace be.Controllers
{
    /// <summary>
    /// Issue Controller
    /// </summary>
    [Route("api/history")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly DbJiraCloneContext _context;
        public HistoryController(DbJiraCloneContext db, IIssueService issueService)
        {
            _context = db;
            _issueService = issueService;
        }

        // Create Issue
        [HttpPost("CreateIssue")]
        public async Task<IActionResult> CreateIssue([FromBody] IssueCreateDTO issue)
        {
            try
            {
                //if(issue == null)
                //{
                //    return BadRequest();
                //}
                var resData = await _issueService.CreateIssue(issue);
                return StatusCode(resData.code, resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //// Get Items select list to Create Issue 
        //[HttpGet("GetItemsCreateIssue")]
        //public async Task<IActionResult> GetItemsCreateIssue()
        //{
        //    try
        //    {
        //        var resData = await _issueService.GetItemsCreateIssue();
        //        return StatusCode(resData.code, resData);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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
        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Add issue success!",
                status = 200,
                data = issue
            });
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
