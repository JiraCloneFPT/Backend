using be.Repositories.CauseCategoryRepository;

namespace be.Services
{
    public class CauseCategoryService : ICauseCategoryService
    {
        public ICauseCategoryRepository _causeCategoryRepo;

        public CauseCategoryService(ICauseCategoryRepository causeCategoryRepo)
        {
            _causeCategoryRepo = causeCategoryRepo;
        }
    }
}
