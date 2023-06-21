using be.DTOs;
using be.Models;
using be.Repositories.IssueRepository;
using be.Services.OtherService;
using be.Services.UserService;
using MailKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace be.Services.IssueService
{
    /// <summary>
    /// Issue Service
    /// </summary>
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;


        private readonly IUserService _userService; 


        public IssueService(IIssueRepository issueRepository, IUserService userService)
        {
            _issueRepository = issueRepository;

            _userService = userService;
        }

        // Edit issue
        public async Task<ResponseDTO> EditIssue(IssueCreateDTO issue)
        {
            try
            {
                var issueEdited = await _issueRepository.EditIssue(issue);
                if (issueEdited == null)
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Edit Issue Failed!"
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Edit Issue Success!",
                        data = issueEdited
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

            
        
      

        // Get issue by id
        public async Task<ResponseDTO> GetIssueById(int id)
        {
            try
            {
                var result = await _issueRepository.GetByIdAsync(id);
                if (result == null)
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Get Issue Failed!"
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Get Issue Success!",
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

        // Create Issue
        public async Task<ResponseDTO> CreateIssue(IssueCreateDTO issue)
        {
            try
            {
                var result = await _issueRepository.CreateIssue(issue);
                if(issue.AttachFile != null)
                {
                    await _issueRepository.AddFile(issue.AttachFile, result);
                }    
                if (result == null)
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Create Issue Failed!"
                    };
                }
                else
                {
                    User assignee = _userService.GetUserById(issue.AssigneeId.Value); 
                    EmailService.Instance.SendMailCreate(result, assignee); 
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
        public async Task<ResponseDTO> GetItemsIssue()
        {
            try
            {
                var result = await _issueRepository.GetItemsIssue();
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

        public IList<ShortDesIssue> GetAllIssueByUserId(int userId)
        {
            return _issueRepository.GetAllIssueByUserId(userId);
        }
    }
}
