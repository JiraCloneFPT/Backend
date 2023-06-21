using be.DTOs;
using be.Models;
using be.Repositories.ExportRepository;
using Microsoft.AspNetCore.Mvc;

namespace be.Services.ExportService
{
    /// <summary>
    /// Interface Issue Service
    /// </summary>
    public interface IExportService
    {
        public CustomFile ExportFileHtml(List<IssueDTO> listIdData);
        public CustomFile ExportFileExcel(List<IssueDTO> listIdData);
        public CustomFile ExportFileWord(int id);
    }
}
