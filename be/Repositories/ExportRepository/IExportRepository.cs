using AutoMapper;
using be.DTOs;
using be.Helpers;
using be.Models;
using be.Services;
using OfficeOpenXml;
using System.Text;

namespace be.Repositories.ExportRepository
{
    public interface IExportRepository
    {
        public CustomFile ExportFileHtml(List<IssueDTO> listIdData);
        public CustomFile ExportFileExcel(List<IssueDTO> listIdData);
        public CustomFile ExportFileWord(int id);

    }
}
