using be.DTOs;
using be.Repositories.ExportRepository;

namespace be.Services.ExportService
{
    /// <summary>
    /// Issue Service
    /// </summary>
    public class ExportService : IExportService
    {
        private readonly IExportRepository _exportRepository;

        public ExportService(IExportRepository issueRepository)
        {
            _exportRepository = issueRepository;
        }

        public CustomFile ExportFileHtml(List<int> data)
        {
            return _exportRepository.ExportFileHtml(data);
        }
        public CustomFile ExportFileExcel(List<int> data)
        {
            return (_exportRepository.ExportFileExcel(data));
        }
        public CustomFile ExportFileWord(int id)
        {
            return _exportRepository.ExportFileWord(id);
        }

    }
}
