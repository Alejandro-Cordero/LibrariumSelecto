using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Repositories;

namespace SocialNetwork.Data.Repositories
{
    public class TypeTopicRepository : Repository<TypeTopic>, ITypeTopicRepository
    {
        public TypeTopicRepository(DbContext context) : base(context)
        {
        }

        private SocialNetworkDbContext SocialNetworkDbContext
        {
            get { return Context as SocialNetworkDbContext; }
        }


    }
}
