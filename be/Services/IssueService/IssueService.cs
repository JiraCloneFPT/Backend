﻿using be.Commons;
using be.DTOs;
using be.Helpers;
using be.Models;
using be.Repositories.HistoryRepository;
using be.Repositories.IssueRepository;
using be.Services.HistoryService;
using be.Services.OtherService;
using be.Services.UserService;
using be.Services.WatcherService;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace be.Services.IssueService
{
    /// <summary>
    /// Issue Service
    /// </summary>
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IUserService _userService; 
        private readonly IWatcherService _watcherService;
        private readonly  IHistoryService _historyService;
       
        public IssueService(IIssueRepository issueRepository, IUserService userService, IWatcherService watcherService, IHistoryService historyService)
        {
            _issueRepository = issueRepository;

            _userService = userService;
            _watcherService = watcherService;
            _historyService = historyService;
        }

        public async Task<ResponseDTO> GetComments(int issueId)
        {
            try
            {
                var result = _issueRepository.GetComments(issueId);
                if (result != null)
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Get Comments Success!",
                        data = result
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Get Comments Failed!"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDTO> AddComment(CommentDTO comment)
        {
            try
            {
                var isCommented = await _issueRepository.AddComment(comment);
                if (isCommented)
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "AddComment Success!",
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "AddComment Failed!"
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

        public async Task<ResponseDTO> ReopenedIssue(int userId, int issueId)
        {
            try
            {
                var isChange = _issueRepository.ChangeStatus(userId, issueId, ((int)Commons.StatusIssue.Reopened));
                var issueEdited = await _issueRepository.GetByIdAsync(issueId);
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueEdited, userId);
                // get issueID 
                int issueID = issueId;
                // get Watcher list
                List<string> listEmailWatchers = _userService.GetListEmailUsers(_watcherService.getListWatcher(issueID));
                if (issueEdited != null && historyCreated != null)
                {
                    HistoryForEmail historyForEmail = _historyService.GetHistoryForEmail(issueID);
                    EmailService.Instance.SendMailUpdate(listEmailWatchers, historyForEmail);
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Change status Issue and Add history success!",
                        data = issueEdited
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Change status OR Add History Failed!"
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

        public async Task<ResponseDTO> InProgessIssue(int userId, int issueId)
        {
            try
            {
                var isChange =  _issueRepository.ChangeStatus(userId, issueId, ((int)Commons.StatusIssue.InProgress)) ;
                var issueEdited = await _issueRepository.GetByIdAsync(issueId);
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueEdited, userId);
                // get issueID 
                int issueID = issueId;

                // get Watcher list
                List<string> listEmailWatchers = _userService.GetListEmailUsers(_watcherService.getListWatcher(issueID));
                if (issueEdited != null && historyCreated != null)
                {
                    HistoryForEmail historyForEmail = _historyService.GetHistoryForEmail(issueID);
                    EmailService.Instance.SendMailUpdate(listEmailWatchers, historyForEmail);
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Change status Issue and Add history success!",
                        data = issueEdited
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Change status OR Add History Failed!"
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

        public async Task<ResponseDTO> RemoveFile(int fileId)
        {
            try
            {
                var isRemoved = await _issueRepository.RemoveFile(fileId);
                if (isRemoved)
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "RemoveFile Success!",
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "RemoveFile Failed!"
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

        public async Task<ResponseDTO> AddFiles(FileDTO fileDTO)
        {
            try
            {
                bool isAdded = false;
                if (fileDTO.IssueId != null && fileDTO.AttachFiles != null)
                {
                    var issue = await  _issueRepository.GetByIdAsync(fileDTO.IssueId);
                    isAdded = isAdded = await _issueRepository.AddFiles(fileDTO.AttachFiles, issue);
                }
                if (isAdded)
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "AddFile Success!",
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "AddFile Failed!"
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

        // GetFilesIssue
        public async Task<ResponseDTO> GetFilesIssue(int issueId)
        {
            try
            {
                var result = await _issueRepository.GetFilesIssue(issueId);
                if (result != null)
                {
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "GetFilesIssue Success!",
                        data = result
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "GetFilesIssue Failed!"
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

        // CancelIssue
        public async Task<ResponseDTO> CancelIssue(IssueCreateDTO issue)
        {
            try
            {
                var issueEdited = await _issueRepository.EditIssue(issue, ((int)Commons.StatusIssue.Cancelled));
                // get issueID 
                int issueID = issue.IssueId.Value;

                // get Watcher list
                List<string> listEmailWatchers = _userService.GetListEmailUsers(_watcherService.getListWatcher(issueID));
                if (issue.AttachFiles != null)
                {
                    await _issueRepository.AddFiles(issue.AttachFiles, issueEdited);
                }
                if (issue.Comment != null)
                {
                    CommentDTO comment = new CommentDTO();
                    comment.IssueId = issue.IssueId;
                    comment.UserId = issue.UserId.Value;
                    comment.CommentContent = issue.Comment;
                    _issueRepository.AddComment(comment);
                }
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueEdited, issue.UserId.Value);
                if (issueEdited != null && historyCreated != null)
                {
                    HistoryForEmail historyForEmail = _historyService.GetHistoryForEmail(issueID);
                    EmailService.Instance.SendMailUpdate(listEmailWatchers, historyForEmail);
                    return new ResponseDTO
                    {
                        code = 200,
                        message = "Cancel Issue and Add history success!",
                        data = issueEdited
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        code = 500,
                        message = "Cancel Issue OR Add History Failed!"
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

        // CloseIssue
        public async Task<ResponseDTO> CloseIssue(IssueCreateDTO issue)
        {
            try
            {
                var issueEdited = await _issueRepository.EditIssue(issue, ((int)Commons.StatusIssue.Closed));
                // get issueID 
                int issueID = issue.IssueId.Value;

                // get Watcher list
                List<string> listEmailWatchers = _userService.GetListEmailUsers(_watcherService.getListWatcher(issueID));
                if (issue.AttachFiles != null)
                {
                    await _issueRepository.AddFiles(issue.AttachFiles, issueEdited);
                }

                if (issue.Comment != null)
                {
                    CommentDTO comment = new CommentDTO();
                    comment.IssueId = issue.IssueId;
                    comment.UserId = issue.UserId.Value;
                    comment.CommentContent = issue.Comment;
                    _issueRepository.AddComment(comment);
                }
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueEdited, issue.UserId.Value);
                if (issueEdited != null && historyCreated != null)
                {
                    HistoryForEmail historyForEmail = _historyService.GetHistoryForEmail(issueID);
                    EmailService.Instance.SendMailUpdate(listEmailWatchers, historyForEmail);
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

        public async Task<ResponseDTO> ResolveIssue(IssueCreateDTO issue)
        {
            try
            {
                var issueEdited = await _issueRepository.EditIssue(issue, ((int)Commons.StatusIssue.Resolve));
                // get issueID 
                int issueID = issue.IssueId.Value;

                // get Watcher list
                List<string> listEmailWatchers = _userService.GetListEmailUsers(_watcherService.getListWatcher(issueID));
                if (issue.AttachFiles != null)
                {
                    await _issueRepository.AddFiles(issue.AttachFiles, issueEdited);
                }
                //if (issue.AttachFile != null)
                //{
                //    await _issueRepository.AddFile(issue.AttachFile, issueEdited);
                //}
                if (issue.Comment != null)
                {
                    CommentDTO comment = new CommentDTO();
                    comment.IssueId = issue.IssueId;
                    comment.UserId = issue.UserId.Value;
                    comment.CommentContent = issue.Comment;
                    _issueRepository.AddComment(comment);
                }
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueEdited, issue.UserId.Value);
                if (issueEdited != null && historyCreated != null)
                {
                    HistoryForEmail historyForEmail = _historyService.GetHistoryForEmail(issueID);
                    EmailService.Instance.SendMailUpdate(listEmailWatchers, historyForEmail);
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

        // Edit issue
        public async Task<ResponseDTO> EditIssue(IssueCreateDTO issue)
        {
            try
            {
                var statusIssueId = (await _issueRepository.GetByIdAsync(issue.IssueId.Value)).StatusIssueId;
                var issueEdited = await _issueRepository.EditIssue(issue, statusIssueId.Value);
                if (issue.AttachFiles != null)
                {
                    await _issueRepository.AddFiles(issue.AttachFiles, issueEdited);
                }
                //if (issue.AttachFile != null)
                //{
                //    await _issueRepository.AddFile(issue.AttachFile, issueEdited);
                //}

                // lấy issueID 
                int issueID = issue.IssueId.Value;

                // lấy danh sách Watcher
                List<string> listEmailWatchers = _userService.GetListEmailUsers(_watcherService.getListWatcher(issueID));
                           
                if(issue.Comment != null)
                {
                    CommentDTO comment = new CommentDTO();
                    comment.IssueId = issue.IssueId;
                    comment.UserId = issue.UserId.Value;
                    comment.CommentContent = issue.Comment;
                    _issueRepository.AddComment(comment);
                }
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueEdited, issue.UserId.Value);

                if (issueEdited != null && historyCreated != null)
                {
                    HistoryForEmail historyForEmail = _historyService.GetHistoryForEmail(issueID);
                    EmailService.Instance.SendMailUpdate(listEmailWatchers, historyForEmail);
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
                if (issue.AttachFiles != null)
                {
                    await _issueRepository.AddFiles(issue.AttachFiles, issueCreated);
                }
                //if (issue.AttachFile != null)
                //{
                //    await _issueRepository.AddFile(issue.AttachFile, issueCreated);
                //}
                var historyCreated = await _issueRepository.CreateHistoryIssue(issueCreated, issue.UserId.Value);
                if (issueCreated != null && historyCreated != null)
                {
                    User assignee = _userService.GetUserById(issue.AssigneeId.Value);
                    EmailService.Instance.SendMailCreate(issueCreated, assignee);
                    //HuyNG5 - auto add reporter to watcher
                    _watcherService.StartWatcherIssue(issueCreated.ReporterId, issueCreated.IssueId);
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
        public async Task<object> AllIssue()
        {
            return await _issueRepository.AllIssue();
        }
        public IList<ShortDesIssue> GetAllIssueByUserId(int userId)
        {
            return _issueRepository.GetAllIssueByUserId(userId);
        }

    }
}
