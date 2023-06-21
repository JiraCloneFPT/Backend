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

namespace be.Controllers
{
    /// <summary>
    /// Issue Controller
    /// </summary>
    [Route("api/export")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly ExportService Export;
        private readonly DbJiraCloneContext _context;
        public ExportController(DbJiraCloneContext db)
        {
            _context = db;
            Export = new ExportService();
        }
        // Export list data by html file
        [HttpPost("list/html")]
        public async Task<ActionResult> ExportHtmlList([FromBody] List<int> listIdData)
        {
            try
            {
                var data = new List<Issue>();
                foreach (int id in listIdData)
                {
                    var _data = await _context.Issues.FindAsync(id);
                    if (_data != null)
                    {
                        data.Add(_data);
                    }
                }
                var result = Export.ExportFileHtml(data);

                return File(result.FileContents, result.ContentType, result.FileName);
            }
            catch
            {
                return BadRequest();
            }
        }
        // Export list data by excel file
        [HttpPost("list/excel")]
        public ActionResult ExportExcelList([FromBody] List<int> listIdData)
        {
            try
            {
                var data = new List<Issue>();
                foreach (int id in listIdData)
                {
                    var _data = _context.Issues.Find(id);
                    if (_data != null)
                    {
                        data.Add(_data);
                    }
                }
                var result = Export.ExportFileExcel(data);
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
                var result = Export.ExportFileWord(id);
                return File(result.FileContents, result.ContentType, result.FileName);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
    
    
}
