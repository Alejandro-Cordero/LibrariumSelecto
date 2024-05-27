using SocialNetwork.Core;
using SocialNetwork.Core.Repositories;
using SocialNetwork.Data.Repositories;

namespace SocialNetwork.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialNetworkDbContext _context;
        private UserRepository _userRepository;
        private TypeGenderRepository _typeGenderRepository;
        private CommentaryRepository _commentaryRepository;
        private RecommendationRepository _recommendationRepository;
        private ArticleRepository _articleRepository;
        private TypeTopicRepository _typeTopicRepository;

        public UnitOfWork(SocialNetworkDbContext context)
        {
            this._context = context;
        }

        public IUserRepository UsersRepo => _userRepository = _userRepository ?? new UserRepository(_context);
        public ITypeGenderRepository TypeGendersRepo => _typeGenderRepository = _typeGenderRepository ?? new TypeGenderRepository(_context);
        public IRecommendationRepository RecomendRepo => _recommendationRepository = _recommendationRepository ?? new RecommendationRepository(_context);
        public IArticleRepository ArticlesRepo => _articleRepository = _articleRepository ?? new ArticleRepository(_context);
        public ITypeTopicRepository TypeTopicRepo => _typeTopicRepository = _typeTopicRepository ?? new TypeTopicRepository(_context);

        public ICommentaryRepository CommentsRepo => _commentaryRepository = _commentaryRepository ?? new CommentaryRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}