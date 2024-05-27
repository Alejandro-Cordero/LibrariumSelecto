
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.ViewModels;

namespace SocialNetwork.Mvc.Models.ViewModels
{
    public class ArticleDetail
    {
        public UserViewModel User { get; set; }
        public ArticleViewModel Article { get; set; }
        public TypeTopicViewModel TypeTopic { get; set; }
        public List<CommentaryViewModel> Commentaries { get; set; }
        public List<RecommendationViewModel> Recommendations { get; set; }
    }
}
