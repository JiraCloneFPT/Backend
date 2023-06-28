using be.Controllers;
using be.Repositories.HistoryRepository;

namespace be.Services.History
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository repository;
        public HistoryService(IHistoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<object> GetElementFirst(int idIssue)
        {
            return await repository.GetElementFirst(idIssue);
        }

        public async Task<List<ObjectHistory>> HandleCompareObject(int idIssue)
        {
            return await repository.HandleCompareObject(idIssue);
        }

    }
}
