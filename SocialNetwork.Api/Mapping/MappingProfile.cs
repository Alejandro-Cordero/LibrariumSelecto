using AutoMapper;
using SocialNetwork.Api.Resources;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<User, UserResource>()
                .ForMember(dest => dest.TypeGenderDescription, opt => opt.MapFrom(src => src.TypeGender != null ? src.TypeGender.Description : null));

            CreateMap<TypeGender, TypeGenderResource>();

            CreateMap<Article, ArticleResource>();

            CreateMap<TypeTopic, TypeTopicResource>();

            CreateMap<Commentary, CommentaryResource>();
            CreateMap<Recommendation, RecommendationResource>();


            // Resource to Domain
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();

            CreateMap<ArticleResource, Article>();
            CreateMap<SaveArticleResource, Article>();

            CreateMap<CommentaryResource, Commentary>();
            CreateMap<RecommendationResource, Recommendation>();

            CreateMap<SaveCommentaryResource, Commentary>();
            CreateMap<SaveRecommendationResource, Recommendation>();

        }
    }
}
