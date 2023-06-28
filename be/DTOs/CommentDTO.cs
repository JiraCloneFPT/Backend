namespace be.DTOs
{
    public class CommentDTO
    {
        public int? UserId { get; set; }
        public int? IssueId { get; set; }
        public string? CommentContent { get; set; }

        public string? FullName { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
