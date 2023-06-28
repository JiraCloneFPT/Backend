using AutoMapper;
using be.DTOs;
using be.Helpers;
using be.Models;
using be.Services.History;
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
        private readonly IHistoryService historyService;
        public HistoryController(IHistoryService historyService)
        {
            this.historyService = historyService;
        }

        [HttpGet("all")]
        public async Task<ActionResult> HandleCompareObject(int idIssue)
        {
            var history = await _context.Histories.Where(x => x.IssueId == idIssue).Select(x => handleData.HandleDataHistory(mapper.Map<HistoryDTO>(x))).OrderByDescending(x => x.UpdateTime).ToListAsync();
            var result = new List<ObjectHistory>();
            if(history.Count >= 2)
            try
            {
                for (int i = 0; i < history.Count - 1; i++)
                {
                    var data = new ObjectHistory();
                    data.EditorName = history[i + 1].EditorName;
                    data.Properties = CompareTwoObject.CompareObjects<HistoryCompareDTO>(mapper.Map<HistoryCompareDTO>(history[i]), mapper.Map<HistoryCompareDTO>(history[i+1]));
                    data.CreateAt = history[i+1].UpdateTime;
                    result.Add(data);
                }
            
            
            return Ok(new
                var result = await historyService.HandleCompareObject(idIssue);
                return Ok(new
                {
                    status = 200,
                    data = result
                });
            }
            catch
            {
                return BadRequest();
            }
            
            
        }
        [HttpGet]
        public async Task<ActionResult> GetElementFirst(int idIssue)
        {
            try
            {
                var result = await historyService.GetElementFirst(idIssue);
                return Ok(result);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("EmailHistory")]
        public async Task<ActionResult> HandleCompareForEmail(int idIssue)
        {
            var history = await _context.Histories.Where(x => x.IssueId == idIssue).OrderByDescending(x => x.UpdateTime).Select(x => handleData.HandleDataHistory(mapper.Map<HistoryDTO>(x))).ToListAsync();
            
            var result = new HistoryForEmail();
            if (history.Count >= 2)
            {
                 
                result.ProjectName = history[0].Project;
                result.ProjectShortName = _context.Projects.FirstOrDefault(x => x.ProjectId == history[0].ProjectId).ShortName;
                result.StatusIssueName = history[0].StatusIssue;
                result.IssueSummary = history[0].Summary;
                result.EditorName = history[0].EditorName;
                result.Properties = CompareTwoObject.CompareObjects<HistoryCompareDTO>(mapper.Map<HistoryCompareDTO>(history[0]), mapper.Map<HistoryCompareDTO>(history[1]));
                result.CreateAt = history[0].UpdateTime;
                result.ReporterEmail = _context.Users.FirstOrDefault(x => x.UserId == history[0].ReporterId).Email;
                result.AssigneeEmail = _context.Users.FirstOrDefault(x => x.UserId == history[0].AssigneeId).Email;

            }

            return Ok(new
            {
                status = 200,
                data = result
            });  
        }
    }
    public class ObjectHistory
    {
        public string EditorName { get; set; }
        public List<Properties> Properties { get; set; }
        public DateTime CreateAt { get; set; }
    }
 
}
