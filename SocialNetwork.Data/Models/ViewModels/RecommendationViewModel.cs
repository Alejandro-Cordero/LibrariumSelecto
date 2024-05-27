namespace SocialNetwork.Data.Models.ViewModels
{
    public class RecommendationViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; } 
        public virtual UserViewModel User { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleViewModel Article { get; set;}
    }
}
