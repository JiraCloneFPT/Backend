using be.Controllers;

namespace be.Services.History
{
    public interface IHistoryService
    {
        Task<List<ObjectHistory>> HandleCompareObject(int idIssue);
        Task<object> GetElementFirst(int idIssue);
    }
}
