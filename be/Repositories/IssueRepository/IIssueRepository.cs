using be.DTOs;
using be.Models;
using be.Repositories.BaseRepository;
using Microsoft.AspNetCore.Mvc;

namespace be.Repositories.IssueRepository
{
    /// <summary>
    /// Interface IssueR epository
    /// </summary>
    public interface IIssueRepository : IBaseRepository<Issue>
    {
        // Get Items select list to Create Issue
        Task<ListItemsOfIssueDTO> GetItemsIssue();

        // Create Issue
        Task<bool> CreateIssue(IssueCreateDTO issue);
        Task<object> GetElement(int id);
        Task<object> AllIssue(int idUser);
        Task<object> MyOpenIssue(int idUser);
        Task<object> ReportByMe(int idUser);
    }
}
