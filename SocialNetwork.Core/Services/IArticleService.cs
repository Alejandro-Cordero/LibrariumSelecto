using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAll();
        Task<Article> GetArticleById(int id);
        Task<Article> CreateArticle(Article newArticle);
        Task UpdateArticle(Article articleToBeUpdated, Article article);
        Task DeleteArticle(Article article);
        Task<IEnumerable<TypeTopic>> GetAllTypeTopic();
    }
}
