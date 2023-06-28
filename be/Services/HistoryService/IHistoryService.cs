using be.Controllers;
using be.Models;

namespace be.Services.HistoryService
{
    public interface IHistoryService
    {
        public be.Models.History GetHistory(int id);
        public HistoryForEmail GetHistoryForEmail(int issueId);
        Task<List<ObjectHistory>> HandleCompareObject(int idIssue);
        Task<object> GetElementFirst(int idIssue);
    }
}
