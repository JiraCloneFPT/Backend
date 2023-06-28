using AutoMapper;
using be.Controllers;
using be.DTOs;
using be.Helpers;
using be.Models;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.HistoryRepository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly DbJiraCloneContext _context;
        private readonly HandleData handleData;
        private readonly Mapper mapper;
        public HistoryRepository()
        {
            _context = new DbJiraCloneContext();
            mapper = MapperConfig.InitializeAutomapper();
            handleData = new HandleData();
        }

        public async Task<List<ObjectHistory>> HandleCompareObject(int idIssue)
        {
            var history = await _context.Histories.Where(x => x.IssueId == idIssue).OrderByDescending(x => x.UpdateTime).Select(x => handleData.HandleDataHistory(mapper.Map<HistoryDTO>(x))).ToListAsync();
            var result = new List<ObjectHistory>();
            if (history.Count >= 2)
            {
                for (int i = 0; i < history.Count - 1; i++)
                {
                    var data = new ObjectHistory();
                    data.EditorName = history[i + 1].EditorName;
                    data.Properties = CompareTwoObject.CompareObjects<HistoryCompareDTO>(mapper.Map<HistoryCompareDTO>(history[i]), mapper.Map<HistoryCompareDTO>(history[i + 1]));
                    data.CreateAt = history[i + 1].UpdateTime;
                    result.Add(data);
                }
            }

            return result;
        }
        public async Task<object> GetElementFirst(int idIssue)
        {
            var history = await _context.Histories.Where(x => x.IssueId == idIssue).OrderByDescending(x => x.UpdateTime).Select(x => handleData.HandleDataHistory(mapper.Map<HistoryDTO>(x))).ToListAsync();
            if(history.Count == 0)
            {
                return new
                {
                    status = 400,
                };
            }
            return new
            {
                status = 200,
                data = history[history.Count - 1]
            };
        }
    }
}
