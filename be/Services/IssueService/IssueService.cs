using be.DTOs;
using be.Models;
using be.Repositories.IssueRepository;
using be.Services.OtherService;
using be.Services.UserService;
using MailKit;

namespace be.Services.IssueService
{
    /// <summary>
    /// Issue Service
    /// </summary>
    public class IssueService : IExportService
    {
        private readonly IExportRepository _issueRepository;

<<<<<<< HEAD
       

        private readonly IUserService _userService; 


        public IssueService(IIssueRepository issueRepository, IUserService userService)
=======
        public IssueService(IExportRepository issueRepository)
>>>>>>> 85de41de62cae4439895b8140225f10fa50b5b7f
        {
            _issueRepository = issueRepository;
            _userService = userService;
            
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
                //if (issue.AttachFile != null)
                //{
                //    await _issueRepository.AddFile(issue.AttachFile, result);
                //}
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

<<<<<<< HEAD
        public void SendEmailCreateIssue()
        {

        }

=======
<<<<<<< HEAD
        public async Task<object> GetElement(int id)
        {
            return await _issueRepository.GetElement(id);
        }

        public async Task<object> GetElementsByIdUser(int idUser , int idComponent)
        {
            return await _issueRepository.GetElementsByIdUser(idUser, idComponent);
        }
=======
>>>>>>> d6fd17adfd157c1db32e46535853e9a8e2bdf35d
>>>>>>> 85de41de62cae4439895b8140225f10fa50b5b7f

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



    }
}
