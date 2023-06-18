using be.Models;

namespace be.Repositories.CauseCategoryRepository
{
    public class CauseCategoryRepository : ICauseCategoryRepository
    {
        private readonly DbJiraCloneContext _context;

        public CauseCategoryRepository()
        {
            _context = new DbJiraCloneContext();
        }
    }
}
