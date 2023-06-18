using be.DTOs;
using be.Models;
using be.Repositories.BaseRepository;

namespace be.Repositories.IssueRepository
{
    /// <summary>
    /// Interface IssueR epository
    /// </summary>
    public interface IIssueRepository : IBaseRepository<Issue>
    {
        // Get Items select list to Create Issue
        Task<ListItemsToCreateIssueDTO> GetItemsCreateIssue();

        // Create Issue
        Task<bool> CreateIssue(IssueCreateDTO issue);

    }
}
