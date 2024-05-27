using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Services
{
    public interface IRecommendationService
    {
        Task<IEnumerable<Recommendation>> GetAll();
        Task<Recommendation> GetRecommendationById(int id);
        Task<Recommendation> CreateRecommendation(Recommendation newRecommendation);
        Task DeleteRecommendation(Recommendation recommendation);

    }
}
