using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Repositories;

namespace SocialNetwork.Data.Repositories
{
    public class RecommendationRepository : Repository<Recommendation>, IRecommendationRepository
    {
        public RecommendationRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Recommendation>> GetAllWithUserAsync()
        {
            return await SocialNetworkDbContext.Recommendations
                .Include(m => m.User)
                .ToListAsync();
        }

        public async Task<Recommendation> GetWithUserByIdAsync(int id)
        {
            return await SocialNetworkDbContext.Recommendations
               .Include(m => m.User)
               .SingleOrDefaultAsync(m => m.Id == id);
        }

        private SocialNetworkDbContext SocialNetworkDbContext
        {
            get { return Context as SocialNetworkDbContext; }
        }
    }
}
