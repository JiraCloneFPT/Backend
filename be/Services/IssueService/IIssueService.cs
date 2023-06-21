﻿using be.DTOs;
using be.Models;
using Microsoft.AspNetCore.Mvc;

namespace be.Services.IssueService
{
    /// <summary>
    /// Interface Issue Service
    /// </summary>
    public interface IIssueService
    {
        // Get Items select list to Create Issue
        Task<ResponseDTO> GetItemsIssue();

        // Create Issue
        Task<ResponseDTO> CreateIssue(IssueCreateDTO issue);
        Task<object> GetElement(int id);
        Task<object> AllIssue(int idUser);
        Task<object> MyOpenIssue(int idUser);
        Task<object> ReportByMe(int idUser);
        // Get Issue By id
        Task<ResponseDTO> GetIssueById(int id);
    }
}
