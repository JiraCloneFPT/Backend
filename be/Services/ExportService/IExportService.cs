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
        public CustomFile ExportFileHtml(List<int> listIdData);
        public CustomFile ExportFileExcel(List<int> listIdData);
        public CustomFile ExportFileWord(int id);
    }
}
