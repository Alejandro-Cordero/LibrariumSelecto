namespace SocialNetwork.Api.Resources
{
    public class ArticleResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int TypeTopicId { get; set; }
        public int UserId { get; set; }
    }
}