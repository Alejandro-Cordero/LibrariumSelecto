namespace SocialNetwork.Api.Resources
{
    public class SaveCommentaryResource
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public int? Rating { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}
