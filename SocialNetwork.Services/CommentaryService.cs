using SocialNetwork.Core;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Services;

namespace SocialNetwork.Services
{
    public class CommentaryService : ICommentaryService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CommentaryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Commentary> CreateComment(Commentary newCommentary)
        {
            await _unitOfWork.CommentsRepo.AddAsync(newCommentary);
            await _unitOfWork.CommitAsync();
            return newCommentary;
        }
        public async Task DeleteComment(Commentary commentary)
        {
            _unitOfWork.CommentsRepo.Remove(commentary);
            await _unitOfWork.CommitAsync();
        }


        public async Task UpdateComment(Commentary commentaryToBeUpdated, Commentary commentary)
        {
            commentaryToBeUpdated.Title = commentary.Title;
            commentaryToBeUpdated.Description = commentary.Description;
            commentaryToBeUpdated.Date = commentary.Date;
            commentaryToBeUpdated.Rating = commentary.Rating;
            commentaryToBeUpdated.UserId = commentary.UserId;
            commentaryToBeUpdated.ArticleId = commentary.ArticleId;

            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Commentary>> GetAll()
        {
            return await _unitOfWork.CommentsRepo
                .GetAllWithUserAsync();
        }

        public async Task<Commentary> GetCommentById(int id)
        {
            return await _unitOfWork.CommentsRepo
                .GetWithUserByIdAsync(id);
        }

    }
}
