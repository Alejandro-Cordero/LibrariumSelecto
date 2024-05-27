using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Repositories;

namespace SocialNetwork.Data.Repositories
{
    internal class CommentaryRepository : Repository<Commentary>, ICommentaryRepository
    {
        private readonly SocialNetworkDbContext _db;
        public CommentaryRepository(SocialNetworkDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Commentary>> GetAllWithUserAsync()
        {
            return await SocialNetworkDbContext.Commentaries
                .Include(m => m.User)
                .ToListAsync();
        }

        public async Task<Commentary> GetWithUserByIdAsync(int id)
        {
            return await SocialNetworkDbContext.Commentaries
                .Include(m => m.User)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        private SocialNetworkDbContext SocialNetworkDbContext
        {
            get { return Context as SocialNetworkDbContext; }
        }
    }
}
