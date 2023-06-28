using be.Models;

namespace be.Services.HistoryService
{
    public interface IHistoryService
    {
        public History GetHistory(int id);
        public List<int> GetTwoMaxHistoryIds(int issueId);
        public HistoryForEmail GetHistoryForEmail(int issueId);

    }
}
