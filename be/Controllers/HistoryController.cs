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
            try
            {
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
    }
    public class ObjectHistory
    {
        public string EditorName { get; set; }
        public List<Properties> Properties { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
