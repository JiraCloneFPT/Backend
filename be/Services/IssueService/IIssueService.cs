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
        Task<ResponseDTO> GetItemsCreateIssue();

        // Create Issue
        Task<ResponseDTO> CreateIssue(IssueCreateDTO issue);
    }
}
