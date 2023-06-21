namespace be.DTOs
{
    public class ProjectInformation
    {
        public ProjectInformation()
        { 

        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ShortName { get; set; }
        public bool? Status { get; set; }
    }
}
