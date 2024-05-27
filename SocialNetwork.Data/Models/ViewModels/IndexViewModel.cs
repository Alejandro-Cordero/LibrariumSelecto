namespace SocialNetwork.Data.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
        public List<TypeTopicViewModel> TypeTopics { get; set; }
        public List<RecommendationViewModel> Recommendations { get; set; }
        public List<CommentaryViewModel> Commentaries { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
