using be.DTOs;
using be.Models;
using Microsoft.AspNetCore.Mvc;

namespace be.Services.IssueService
{
    /// <summary>
    /// Interface Issue Service
    /// </summary>
    public interface IIssueService
    {
        // Edit issue
        Task<ResponseDTO> EditIssue(IssueCreateDTO issue);

        // Get Items select list to Create Issue
        Task<ResponseDTO> GetItemsIssue();
        // Create Issue
        Task<ResponseDTO> CreateIssue(IssueCreateDTO issue);
        Task<object> GetElement(int id);
<<<<<<< HEAD
        Task<object> AllIssue(int idUser);
        Task<object> MyOpenIssue(int idUser);
        Task<object> ReportByMe(int idUser);
        // Get Issue By id
        Task<ResponseDTO> GetIssueById(int id);
=======
        Task<object> GetElementsByIdUser(int idUser, int idComponent);

        // Get Issue By id
        Task<ResponseDTO> GetIssueById(int id);

        //Phần của Huy
        public IList<ShortDesIssue> GetAllIssueByUserId(int userId);
>>>>>>> feffadf24f2f3ec12b83df757bfb475b17c93a31
    }
}
