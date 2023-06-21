using be.DTOs;
using be.Models;
using be.Repositories.BaseRepository;

namespace be.Repositories.IssueRepository
{
    /// <summary>
    /// Interface IssueR epository
    /// </summary>
    public interface IExportRepository : IBaseRepository<Issue>
    {
        // Get Items select list to Create Issue
        Task<ListItemsOfIssueDTO> GetItemsIssue();
        // Create Issue
<<<<<<< HEAD
        Task<Issue> CreateIssue(IssueCreateDTO issue);
      
=======
        Task<bool> CreateIssue(IssueCreateDTO issue);
        Task<object> GetElement(int id);
        Task<object> GetElementsByIdUser(int idUser, int idComponent);

        //Phần của Huy
        public IList<ShortDesIssue> GetAllIssueByUserId(int userId);
    }
}
