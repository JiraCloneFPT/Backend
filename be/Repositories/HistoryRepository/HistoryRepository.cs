using AutoMapper;
using be.Controllers;
using be.DTOs;
using be.Helpers;
using be.Models;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Bibliography;

namespace be.Repositories.HistoryRepository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly DbJiraCloneContext _context;
        private readonly HandleData handleData;
        private readonly Mapper mapper;
        private readonly HandleData handleData;

        public HistoryRepository(DbJiraCloneContext jiraCloneContext)
        {
            _context = jiraCloneContext;
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
        public History GetHistory(int id)
        {
            return _context.Histories.FirstOrDefault(x => x.HistoryId == id);
        }
        public HistoryForEmail GetHistoryForEmail (int issueId)
            {
            var history = _context.Histories.Where(x => x.IssueId == issueId).OrderByDescending(x => x.HistoryId).Select(x => handleData.HandleDataHistory(mapper.Map<HistoryDTO>(x))).ToList();

            var result = new HistoryForEmail();
            if (history.Count >= 2)
                {

                result.ProjectName = history[0].Project;
                result.IssueId = issueId;
                result.ProjectShortName = _context.Projects.FirstOrDefault(x => x.ProjectId == history[0].ProjectId).ShortName;
                result.StatusIssueName = history[0].StatusIssue;
                result.IssueSummary = history[0].Summary;
                result.EditorName = history[0].EditorName;
                result.Properties = CompareTwoObject.CompareObjects<HistoryCompareDTO>(mapper.Map<HistoryCompareDTO>(history[0]), mapper.Map<HistoryCompareDTO>(history[1]));
                result.CreateAt = history[0].UpdateTime;
                result.ReporterEmail = _context.Users.FirstOrDefault(x => x.UserId == history[0].ReporterId).Email;
                result.AssigneeEmail = _context.Users.FirstOrDefault(x => x.UserId == history[0].AssigneeId).Email;
            }
            return result;
        }


    }
}
