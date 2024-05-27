using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Repositories
{
    public interface IRecommendationRepository : IRepository<Recommendation>
    {
        Task<IEnumerable<Recommendation>> GetAllWithUserAsync();
        Task<Recommendation> GetWithUserByIdAsync(int id);

        /*Task<User> GetUserByIdAsync(int id);
        Task<Article> GetArticleById(int id);*/

    }
}
