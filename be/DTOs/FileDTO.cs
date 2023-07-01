namespace be.DTOs
{
    public class FileDTO
    {

        public IFormFile? AttachFile { get; set; }

        public List<IFormFile>? AttachFiles { get; set; }

        public int IssueId { get; set; }


    }
}
