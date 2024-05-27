using SocialNetwork.Core.Repositories;

namespace SocialNetwork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UsersRepo { get; }
        ICommentaryRepository CommentsRepo { get; }
        IRecommendationRepository RecomendRepo { get; }

        ITypeGenderRepository TypeGendersRepo { get; }
        IArticleRepository ArticlesRepo { get; }
        ITypeTopicRepository TypeTopicRepo { get; }
        Task<int> CommitAsync();
    }
}