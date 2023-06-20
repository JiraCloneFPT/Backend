using be.DTOs;
using be.Models;
using be.Repositories.IssueRepository;

namespace be.Services.IssueService
{
    /// <summary>
    /// Issue Service
    /// </summary>
    public class IssueService : IExportService
    {
        private readonly IExportRepository _issueRepository;

        public IssueService(IExportRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        // Create Issue
        public async Task<ResponseDTO> CreateIssue(IssueCreateDTO issue)
        {
            try
            {
                var isCreated = await _issueRepository.CreateIssue(issue);
                if (isCreated == false)
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Create Issue Failed!"
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Create Issue Success!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    code = 500,
                    message = ex.Message
                };
            }
        }

        public async Task<object> GetElement(int id)
        {
            return await _issueRepository.GetElement(id);
        }

        public async Task<object> GetElementsByIdUser(int idUser , int idComponent)
        {
            return await _issueRepository.GetElementsByIdUser(idUser, idComponent);
        }

        // Get Items Create Issue
        public async Task<ResponseDTO> GetItemsCreateIssue()
        {
            try
            {
                var result = await _issueRepository.GetItemsCreateIssue();
                if (result == null)
                {
                    return new ResponseDTO
                    {
                        code = 400,
                        message = "Does not Get Items Create Issue"
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Success",
                        data = result
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    code = 500,
                    message = ex.Message
                };
            }
        }



    }
}
