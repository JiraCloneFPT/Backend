using be.Controllers;

namespace be.Repositories.HistoryRepository
{
    public interface IHistoryRepository
    {
        Task<List<ObjectHistory>> HandleCompareObject(int idIssue);
        Task<object> GetElementFirst(int idIssue);
    }
}
