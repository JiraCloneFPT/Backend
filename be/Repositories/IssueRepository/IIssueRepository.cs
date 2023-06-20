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
        Task<bool> CreateIssue(IssueCreateDTO issue);
<<<<<<< HEAD
        Task<object> GetElement(int id);
        Task<object> GetElementsByIdUser(int idUser, int idComponent);
=======


>>>>>>> d6fd17adfd157c1db32e46535853e9a8e2bdf35d
    }
}
