using be.DTOs;
using be.Models;

namespace be.Services.IssueService
{
    /// <summary>
    /// Interface Issue Service
    /// </summary>
    public interface IIssueService
    {
        // Get Items select list to Create Issue
        Task<ResponseDTO> GetItemsIssue();
        // Create Issue
        Task<ResponseDTO> CreateIssue(IssueCreateDTO issue);
        Task<object> GetElement(int id);
        Task<object> GetElementsByIdUser(int idUser, int idComponent);
        // Get Issue By id
        Task<ResponseDTO> GetIssueById(int id);

    }
}
