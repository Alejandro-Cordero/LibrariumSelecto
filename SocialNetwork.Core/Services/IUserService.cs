using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);
        Task<IEnumerable<TypeGender>> GetAllTypeGenders();
    }
}
