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

        public List<int> GetTwoMaxHistoryIds(int issueId)
        {
            return _historyRepository.GetTwoMaxHistoryIds(issueId);
        }

        public HistoryForEmail GetHistoryForEmail(int issueId)
        {
            return _historyRepository.GetHistoryForEmail(issueId);
        }

    }
}
