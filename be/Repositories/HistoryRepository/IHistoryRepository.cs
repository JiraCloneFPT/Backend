using be.Models;

namespace be.Repositories.HistoryRepository
{
    public interface IHistoryRepository
    {
        public History GetHistory(int id);
        public List<int> GetTwoMaxHistoryIds(int issueId);

        public HistoryForEmail GetHistoryForEmail(int issueId);

    }
}
