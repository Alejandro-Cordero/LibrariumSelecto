using SocialNetwork.Core;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Services;

namespace SocialNetwork.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Article> CreateArticle(Article newArticle)
        {
            await _unitOfWork.ArticlesRepo.AddAsync(newArticle);
            await _unitOfWork.CommitAsync();
            return newArticle;
        }

        public async Task DeleteArticle(Article article)
        {
            _unitOfWork.ArticlesRepo.Remove(article);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _unitOfWork.ArticlesRepo.GetAllWithTypeTopicAsync();
        }

        public async Task<IEnumerable<TypeTopic>> GetAllTypeTopic()
        {
            return await _unitOfWork.TypeTopicRepo.GetAllAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _unitOfWork.ArticlesRepo.GetWithTypeTopicByIdAsync(id);
        }

        public async Task UpdateArticle(Article articleToBeUpdated, Article article)
        {
            articleToBeUpdated.Title = article.Title;
            articleToBeUpdated.Content = article.Content;
            articleToBeUpdated.CreationDate = DateTime.Now;
            articleToBeUpdated.TypeTopicId = article.TypeTopicId;
            articleToBeUpdated.UserId = article.UserId;

            await _unitOfWork.CommitAsync();
        }
    }
}
