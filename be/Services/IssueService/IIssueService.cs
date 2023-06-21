using be.DTOs;
using be.Models;

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

        // Get Issue By id
        Task<ResponseDTO> GetIssueById(int id);
    }
}
