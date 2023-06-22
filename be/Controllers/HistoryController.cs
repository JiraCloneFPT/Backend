using AutoMapper;
using be.DTOs;
using be.Helpers;
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
        private readonly DbJiraCloneContext _context;
        private readonly Mapper mapper;
        private readonly HandleData handleData;
        public HistoryController(DbJiraCloneContext db)
        {
            _context = db;
            mapper = MapperConfig.InitializeAutomapper();
            handleData = new HandleData();
        }

        [HttpGet]
        public async Task<ActionResult> HandleCompareObject(int idIssue)
        {
            var history = await _context.Histories.Where(x => x.IssueId == idIssue).ToListAsync();
            var result = new List<ObjectHistory>();
            if(history.Count >= 2)
            {
                for (int i = 0; i < history.Count - 1; i++)
                {
                    var data = new ObjectHistory();
                    data.IdHistory1 = history[i].HistoryId;
                    data.IdHistory2 = history[i + 1].HistoryId;
                    data.Properties = CompareTwoObject.CompareObjects<History>(history[i], history[i + 1]);
                    data.CreateAt = history[i].CreateTime;
                    result.Add(data);
                }
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
        public int IdHistory1 { get; set; }
        public int IdHistory2 { get; set; }
        public List<Properties> Properties { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
