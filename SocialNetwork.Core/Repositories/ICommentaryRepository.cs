using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Repositories
{
    public interface ICommentaryRepository : IRepository<Commentary>
    {
        //Task<Commentary> GetCommentById(int id);

        Task<IEnumerable<Commentary>> GetAllWithUserAsync();
        Task<Commentary> GetWithUserByIdAsync(int id);

        //Task<User> GetWithUserNameAsync(int idUser, int idArt);
        //Task<Article> GetArticleByIdAsync(int id);

    }
}
