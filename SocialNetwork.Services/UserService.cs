using SocialNetwork.Core;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Services;

namespace SocialNetwork.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.UsersRepo.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.UsersRepo.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.UsersRepo
                .GetAllWithTypeGenderAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.UsersRepo
                .GetWithTypeGenderByIdAsync(id);
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Birthdate = user.Birthdate;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.Login = user.Login;
            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;
            userToBeUpdated.TypeGenderId = user.TypeGenderId;
            userToBeUpdated.Phone = user.Phone;

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TypeGender>> GetAllTypeGenders()
        {
            return await _unitOfWork.TypeGendersRepo
                .GetAllAsync();
        }
    }
}