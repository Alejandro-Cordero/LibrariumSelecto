using SocialNetwork.Core.Models;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.ViewModels;
namespace SocialNetwork.Mvc.Models
{
    public static class MapperDTO
    {
        private static readonly SocialNetworkDbContext socialNetworkDbContext;

        public static List<UserViewModel> ListUsers(List<User> listUsers)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var user in listUsers)
            {
                users.Add(MapUsuario(user));
            }

            return users;
        }
        public static List<ArticleViewModel> ListArticles(List<Article> listArticles)
        {
            List<ArticleViewModel> articles = new List<ArticleViewModel>();
            foreach (var article in listArticles)
            {
                articles.Add(MapArticle(article));
            }

            return articles;
        }
        public static List<TypeTopicViewModel> ListTopics(List<TypeTopic> listTopics)
        {
            List<TypeTopicViewModel> topics = new List<TypeTopicViewModel>();
            foreach (var topic in listTopics)
            {
                topics.Add(MapTopic(topic));
            }

            return topics;
        }
        public static UserViewModel MapUsuario(User user)
        {
            var usuario = new UserViewModel();
            usuario.Id = user.Id;
            usuario.Login = user.Login;
            usuario.Birthdate = user.Birthdate;
            usuario.Email = user.Email;
            usuario.FirstName = user.FirstName;
            usuario.LastName = user.LastName;
            usuario.Password = user.Password;
            usuario.Phone = user.Phone;

            return usuario;
        }

        public static ArticleViewModel MapArticle(Article articleM)
        {
            ArticleViewModel article = new();
            article.Id = articleM.Id;
            article.Title = articleM.Title;
            article.Content = articleM.Content;
            article.CreationDate = articleM.CreationDate;
            article.UserId = articleM.UserId;
            article.TypeTopicId = articleM.TypeTopicId; 

            return article;
        }

        public static TypeTopicViewModel MapTopic(TypeTopic topicM)
        {
            var topic = new TypeTopicViewModel();
            topic.Id = topicM.Id;
            topic.Description = topicM.Description;

            return topic;
        }

        public static List<CommentaryViewModel> ListComments(List<Commentary> listCommentaries)
        {
            List<CommentaryViewModel> comments = new List<CommentaryViewModel>();
            foreach (var comment in listCommentaries)
            {
                comments.Add(MapComment(comment));
            }

            return comments;
        }

        public static CommentaryViewModel MapComment(Commentary commentaryM)
        {
            var comment = new CommentaryViewModel();
            comment.Id = commentaryM.Id;
            comment.Title = commentaryM.Title;
            comment.Description = commentaryM.Description;
            comment.Date = commentaryM.Date;
            comment.Rating = commentaryM.Rating;
            comment.UserId = commentaryM.UserId;
            comment.User = MapUsuario(commentaryM.User);
            comment.Article = MapArticle(commentaryM.Article);
            comment.ArticleId = commentaryM.ArticleId;

            return comment;
        }

        public static RecommendationViewModel MapRecommendation(Recommendation recommendationM)
        {
            var recommendation = new RecommendationViewModel();
            recommendation.Id = recommendationM.Id;
            recommendation.Date = recommendationM.Date;
            recommendation.UserId = recommendationM.UserId;
            recommendation.User = MapUsuario(recommendationM.User);
            recommendation.Article = MapArticle(recommendationM.Article);
            recommendation.ArticleId = recommendationM.ArticleId;

            return recommendation;
        }

        public static List<RecommendationViewModel> ListRecommendations(List<Recommendation> listRecommendations)
        {
            List<RecommendationViewModel> recommendations = new List<RecommendationViewModel>();
            
            foreach (var recommendation in listRecommendations)
            {
                recommendations.Add(MapRecommendation(recommendation));
            }

            return recommendations;
        }
    }
}
