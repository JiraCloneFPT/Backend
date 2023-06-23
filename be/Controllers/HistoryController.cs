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
            var history = await _context.Histories.Where(x => x.IssueId == idIssue).Select(x => handleData.HandleDataHistory(mapper.Map<HistoryDTO>(x))).ToListAsync();
            var result = new List<ObjectHistory>();
            if(history.Count >= 2)
            {
                for (int i = 0; i < history.Count - 1; i++)
                {
                    var data = new ObjectHistory();
                    data.EditorName = history[i + 1].EditorName;
                    data.Properties = CompareTwoObject.CompareObjects<HistoryCompareDTO>(mapper.Map<HistoryCompareDTO>(history[i]), mapper.Map<HistoryCompareDTO>(history[i+1]));
                    data.CreateAt = history[i+1].CreateTime;
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
        public string EditorName { get; set; }
        public List<Properties> Properties { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
