using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<IEnumerable<Article>> GetAllWithTypeTopicAsync();
        Task<Article> GetWithTypeTopicByIdAsync(int id);
    }
}
