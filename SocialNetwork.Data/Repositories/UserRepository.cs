using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Repositories;

namespace SocialNetwork.Data.Repositories
{

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SocialNetworkDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<User>> GetAllWithTypeGenderAsync()
        {
            return await SocialNetworkDbContext.Users
                .Include(m => m.TypeGender)
                .ToListAsync();
        }

        public async Task<User> GetWithTypeGenderByIdAsync(int id)
        {
            return await SocialNetworkDbContext.Users
                .Include(m => m.TypeGender)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        private SocialNetworkDbContext SocialNetworkDbContext
        {
            get { return Context as SocialNetworkDbContext; }
        }
    }
}