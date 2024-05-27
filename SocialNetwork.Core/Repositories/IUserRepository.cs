using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithTypeGenderAsync();
        Task<User> GetWithTypeGenderByIdAsync(int id);
    }
}
