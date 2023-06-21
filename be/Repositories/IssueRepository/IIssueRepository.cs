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
<<<<<<< HEAD
        Task<bool> CreateIssue(IssueCreateDTO issue);
        Task<object> GetElement(int id);
        Task<object> AllIssue(int idUser);
        Task<object> MyOpenIssue(int idUser);
        Task<object> ReportByMe(int idUser);
=======

        Task<Issue> CreateIssue(IssueCreateDTO issue);
      

        Task<object> GetElement(int id);
        Task<object> GetElementsByIdUser(int idUser, int idComponent);

        //Phần của Huy
        public IList<ShortDesIssue> GetAllIssueByUserId(int userId);
>>>>>>> feffadf24f2f3ec12b83df757bfb475b17c93a31
    }
}
