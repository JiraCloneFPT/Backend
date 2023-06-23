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
        Task<bool> AddFile(IFormFile file, Issue issue);

        // Edit Issue
        Task<Issue> EditIssue(IssueCreateDTO issue);

        // Get Items select list to Create Issue
        Task<ListItemsOfIssueDTO> GetItemsIssue();
        // Create Issue

        Task<Issue> CreateIssue(IssueCreateDTO issue);


        Task<object> GetElement(int id);
        //Phần của Huy
        public IList<ShortDesIssue> GetAllIssueByUserId(int userId);
        Task<object> AllIssue();
        Task<object> MyOpenIssue(int idUser);
        Task<object> ReportByMe(int idUser);
    }
}
