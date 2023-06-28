using be.Controllers;
using be.Models;
using be.Repositories.HistoryRepository;

namespace be.Services.HistoryService
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository; 

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }
        public History GetHistory(int id)
        {
            return _historyRepository.GetHistory(id);
        }


        public HistoryForEmail GetHistoryForEmail(int issueId)
        {
            return _historyRepository.GetHistoryForEmail(issueId);
        }

        public async Task<object> GetElementFirst(int idIssue)
        {
            return await _historyRepository.GetElementFirst(idIssue);
        }

        public async Task<List<ObjectHistory>> HandleCompareObject(int idIssue)
        {
            return await _historyRepository.HandleCompareObject(idIssue);
        }

    }
}
