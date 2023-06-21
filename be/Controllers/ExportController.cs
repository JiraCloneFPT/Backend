using be.Models;
using be.Services.IssueService;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Aspose.Words;
using System.Text;
using System.Text.RegularExpressions;
using Issue = be.Models.Issue;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Aspose.Words.XAttr;
using be.Services;
using be.Services.ExportService;
using AutoMapper;
using be.Helpers;
using be.DTOs;

namespace be.Controllers
{
    /// <summary>
    /// Issue Controller
    /// </summary>
    [Route("api/export")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IExportService exportService;
        private readonly DbJiraCloneContext _context;
        public ExportController(DbJiraCloneContext db, IExportService export)
        {
            _context = db;
            exportService = export;
        }
        // Export list data by html file
        [HttpPost("list/html")]
        public async Task<ActionResult> ExportHtmlList([FromBody] List<IssueDTO> listIdData)
        {
            try
            {
                
                var result = exportService.ExportFileHtml(listIdData);

                return File(result.FileContents, result.ContentType, result.FileName);
            }
            catch
            {
                return BadRequest();
            }
        }
        // Export list data by excel file
        [HttpPost("list/excel")]
        public ActionResult ExportExcelList([FromBody] List<IssueDTO> listIdData)
        {
            try
            {
                var result = exportService.ExportFileExcel(listIdData);
                return File(result.FileContentsStream, result.ContentType, result.FileName);
            }
            catch
            {
                return BadRequest();
            }
        }
        // Export detail issue by file word
        [HttpPost("list/word")]
        public ActionResult ExportWordList([FromBody] int id)
        {
            try
            {
                var result = exportService.ExportFileWord(id);
                return File(result.FileContents, result.ContentType, result.FileName);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
    
    
}
