using be.DTOs;
using be.Models;
using be.Repositories.IssueRepository;
using be.Services.OtherService;
using be.Services.UserService;

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
                if (issue.AttachFile != null)
                {
                    await _issueRepository.AddFile(issue.AttachFile, issueEdited);
                }
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueEdited, issue.UserId.Value);
                if (issueEdited != null && historyCreated != null)
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Edit Issue and Add history success!",
                        data = issueEdited
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Edit Issue OR Add History Failed!"
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
                var issueCreated = await _issueRepository.CreateIssue(issue);
                if(issue.AttachFile != null)
                {
                    await _issueRepository.AddFile(issue.AttachFile, issueCreated);
                }
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueCreated, issue.UserId.Value);
                if (issueCreated != null && historyCreated != null)
                {
                    User assignee = _userService.GetUserById(issue.AssigneeId.Value);
                    EmailService.Instance.SendMailCreate(issueCreated, assignee);
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Create Issue Success!"
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Create Issue Failed!"
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

        public async Task<object> MyOpenIssue(int idUser)
        {
            return await _issueRepository.MyOpenIssue(idUser);
        }
        public async Task<object> ReportByMe(int idUser)
        {
            return await _issueRepository.ReportByMe(idUser);
        }
        public async Task<object> AllIssue(int idUser)
        {
            return await _issueRepository.AllIssue(idUser);
        }
        public IList<ShortDesIssue> GetAllIssueByUserId(int userId)
        {
            return _issueRepository.GetAllIssueByUserId(userId);
        }
    }
}
