using SocialNetwork.Core.Models;
using SocialNetwork.Core.Repositories;

namespace SocialNetwork.Data.Repositories
{
    public class TypeGenderRepository : Repository<TypeGender>, ITypeGenderRepository
    {
        public TypeGenderRepository(SocialNetworkDbContext context)
            : base(context)
        { }

        private SocialNetworkDbContext SocialNetworkDbContext
        {
            get { return Context as SocialNetworkDbContext; }
        }
    }
}