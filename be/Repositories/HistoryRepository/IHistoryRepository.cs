using be.Models;
using be.Controllers;

namespace be.Repositories.HistoryRepository
{
    public interface IHistoryRepository
    {
        Task<List<ObjectHistory>> HandleCompareObject(int idIssue);
        Task<object> GetElementFirst(int idIssue);
        public History GetHistory(int id);
        public HistoryForEmail GetHistoryForEmail(int issueId);

    }
}
