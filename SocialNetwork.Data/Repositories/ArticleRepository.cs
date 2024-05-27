using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Repositories;

namespace SocialNetwork.Data.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(SocialNetworkDbContext context) : base(context) { }

        public async Task<IEnumerable<Article>> GetAllWithTypeTopicAsync()
        {
            return await SocialNetworkDbContext.Articles
                .Include(m => m.TypeTopic)
                .Include(m => m.User)
                .ToListAsync();
        }

        public async Task<Article> GetWithTypeTopicByIdAsync(int id)
        {
            return await SocialNetworkDbContext.Articles
                .Include(m => m.TypeTopic)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        private SocialNetworkDbContext SocialNetworkDbContext
        {
            get { return Context as SocialNetworkDbContext; }
        }
    }
}
