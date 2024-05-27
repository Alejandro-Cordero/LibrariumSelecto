namespace SocialNetwork.Api.Resources
{
    public class RecommendationResource
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}
