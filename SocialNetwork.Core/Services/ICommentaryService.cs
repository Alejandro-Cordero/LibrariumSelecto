using SocialNetwork.Core.Models;

namespace SocialNetwork.Core.Services
{
    public interface ICommentaryService
    {
        Task<IEnumerable<Commentary>> GetAll(); // obtener todos los comentarios de un articulo
        Task<Commentary> GetCommentById(int id);
        Task<Commentary> CreateComment(Commentary newCommentary);
        Task UpdateComment(Commentary commentaryToBeUpdated, Commentary commentary);
        Task DeleteComment(Commentary commentary);


    }
}
