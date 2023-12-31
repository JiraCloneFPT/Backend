﻿using AutoMapper;
using be.DTOs;
using be.Helpers;
using be.Models;
using be.Services.IssueService;
using be.Services.OtherService;
using be.Services.UserService;
using be.Services.WatcherService;
using DocumentFormat.OpenXml.Bibliography;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace be.Controllers
{
    /// <summary>
    /// Issue Controller
    /// </summary>
    [Route("api/issue")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly Mapper mapper;
        private readonly HandleData handleData;
        private readonly DbJiraCloneContext _context;
        private readonly IWatcherService _watcherService;

        private readonly IUserService _userService;

        public IssueController(DbJiraCloneContext db, IIssueService issueService)
        {
            mapper = MapperConfig.InitializeAutomapper();
            _context = db;
            _issueService = issueService;
            handleData = new HandleData();
            _userService = new UserService();
            _watcherService = new WatcherService();

        }

        // Get Comments
        [HttpGet("getComments")]
        public async Task<IActionResult> GetComments(int issueId)
        {
            try
            {
                var resData = await _issueService.GetComments(issueId);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Add comment 
        [HttpPost("addComment")]
        public async Task<ActionResult> AddComment(CommentDTO comment)
        {
            try
            {
                if (comment == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.AddComment(comment);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // InProgress Issue
        [HttpPut("reopened")]
        public async Task<ActionResult> ReopenedIssue(int userId, int issueId)
        {
            try
            {
                var resData = await _issueService.ReopenedIssue(userId, issueId);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // InProgress Issue
        [HttpPut("inProgress")]
        public async Task<ActionResult> InProgressIssue(int userId, int issueId)
        {
            try
            {
                var resData = await _issueService.InProgessIssue(userId, issueId);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // remove File Issue
        [HttpDelete("removeFile")]
        public async Task<ActionResult> RemoveFile(int fileId)
        {
            try
            {
                var resData = await _issueService.RemoveFile(fileId);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // cancel Issue
        [HttpPost("addFile")]
        public async Task<ActionResult> AddFile([FromForm] FileDTO fileDTO)
        {
            try
            {
                if (fileDTO == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.AddFiles(fileDTO);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // cancel Issue
        [HttpGet("getFilesIssue")]
        public async Task<ActionResult> GetFilesIssue(int issueId)
        {
            try
            {
                var resData = await _issueService.GetFilesIssue(issueId);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // cancel Issue
        [HttpPut("cancel")]
        public async Task<ActionResult> CancelIssue([FromForm] IssueCreateDTO issue)
        {
            try
            {
                if (issue == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.CancelIssue(issue);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // close Issue
        [HttpPut("close")]
        public async Task<ActionResult> CloseIssue([FromForm] IssueCreateDTO issue)
        {
            try
            {
                if (issue == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.CloseIssue(issue);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // resolve Issue
        [HttpPut("resolve")]
        public async Task<ActionResult> ResloveIssue([FromForm] IssueCreateDTO issue)
        {
            try
            {
                if (issue == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.ResolveIssue(issue);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Edit Issue
        [HttpPut("edit")]
        public async Task<ActionResult> Edit([FromForm] IssueCreateDTO issue)
        {
            try
            {
                if (issue == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.EditIssue(issue);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get issue by id 
        [HttpGet("GetIssueById")]
        public async Task<IActionResult> GetIssueById(int id)
        {
            try
            {
                var resData = await _issueService.GetIssueById(id);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Create Issue
        [HttpPost("addWithFile")]
        public async Task<ActionResult> addWithFile([FromForm] IssueCreateDTO issue)
        {
            try
            {
                if (issue == null)
                {
                    return BadRequest();
                }
                var resData = await _issueService.CreateIssue(issue);
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get Items select list to Create Issue 
        [HttpGet("GetItemsIssue")]
        public async Task<IActionResult> GetItemsIssue()
        {
            try
            {
                var resData = await _issueService.GetItemsIssue();
                return Ok(resData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Route get issue by id
        [HttpGet]
        public async Task<ActionResult> GetElement(int id)
        {
            try
            {
                return Ok(await _issueService.GetElement(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        // Route get all issue
        [HttpGet("all")]
        public async Task<ActionResult> GetElements()
        {
            try
            {
                var data = await _context.Issues.ToListAsync();
                return Ok(new
                {
                    status = 200,
                    data
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]

        public async Task<ActionResult> Delete([FromBody] int id)
        {
            var element = await _context.Issues.FindAsync(id);
            if (element == null)
            {
                return Ok(new
                {
                    message = "The issue doesn't exist in database!",
                    status = 404
                });
            }
            try
            {
                _context.Issues.Remove(element);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "Delete issue success!",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    message = "Error system!",
                    status = 400,
                    data = e.Message
                });
            }
        }
        [HttpGet("GetAllIsseByUserId")]
        public ActionResult GetAllIsseByUserId(int userId)
        {
            try
            {
                var issueList = _issueService.GetAllIssueByUserId(userId);
                return Ok(issueList);
            }
            catch
            {
                return BadRequest();
            }
        }

        #region HIEUVM15

        [HttpGet("myopenissue")]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> MyOpenIssue(int idUser)
        {
            try
            {
                var result = await _issueService.MyOpenIssue(idUser);
                return Ok(result);
            }

            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("reportbyme")]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> ReportByMe(int idUser)
        {
            try
            {
                var result = await _issueService.ReportByMe(idUser);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("allissue")]
        public async Task<ActionResult<IEnumerable<IssueDTO>>> AllIssue()
        {
            try
            {
                var result = await _issueService.AllIssue();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion


        #region HuyNG5 - Code bổ sung
        [HttpPost("startWatcher")]
        public async Task<ActionResult> StartWatcher(int userId, int issueId)
        {
            try
            {
                var checkUser = _userService.GetUserById(userId);
                if(checkUser == null)
                {
                    return BadRequest();
                }
                var checkIssue = _issueService.GetIssueById(issueId);
                if(checkIssue == null)
                {
                    return BadRequest();
                }
                _watcherService.StartWatcherIssue(userId, issueId);
                return Ok(new {
                    message = "Start successfully",
                    status = 200,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("stopWatcher")]
        public async Task<ActionResult> StopWatcher(int userId, int issueId)
        {
            try
            {
                var checkUser = _userService.GetUserById(userId);
                if (checkUser == null)
                {
                    return BadRequest();
                }
                var checkIssue = _issueService.GetIssueById(issueId);
                if (checkIssue == null)
                {
                    return BadRequest();
                }
                _watcherService.StopWatcherIssue(userId, issueId);
                return Ok(new
                {
                    message = "Stop successfully",
                    status = 200,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("countWatcher")]
        public async Task<ActionResult> CountWatcher (int issueId)
        {
            try
            {
                return Ok(_watcherService.CountWatcher(issueId));
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("checkWatcher")]
        public async Task<ActionResult> CheckWatcher (int issueId, int userId)
        {
            try
            {
                return Ok(_watcherService.CheckWatcher(issueId, userId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

