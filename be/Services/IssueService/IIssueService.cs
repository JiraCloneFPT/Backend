using be.DTOs;
using be.Models;

namespace be.Services.IssueService
{
    /// <summary>
    /// Interface Issue Service
    /// </summary>
    public interface IExportService
    {
        // Get Items select list to Create Issue
        Task<ResponseDTO> GetItemsCreateIssue();

        // Create Issue
        Task<ResponseDTO> CreateIssue(IssueCreateDTO issue);
        Task<object> GetElement(int id);
        Task<object> GetElementsByIdUser(int idUser, int idComponent);
    }
}
