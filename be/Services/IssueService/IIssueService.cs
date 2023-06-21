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
        Task<ResponseDTO> GetItemsIssue();

        // Create Issue
        Task<ResponseDTO> CreateIssue(IssueCreateDTO issue);
<<<<<<< HEAD
        Task<object> GetElement(int id);
        Task<object> GetElementsByIdUser(int idUser, int idComponent);
=======

        // Get Issue By id
        Task<ResponseDTO> GetIssueById(int id);
>>>>>>> d6fd17adfd157c1db32e46535853e9a8e2bdf35d
    }
}
