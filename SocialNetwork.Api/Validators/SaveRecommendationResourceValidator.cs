using FluentValidation;
using SocialNetwork.Api.Resources;

namespace SocialNetwork.Api.Validators
{
    public class SaveRecommendationResourceValidator : AbstractValidator<SaveRecommendationResource>
    {
        public SaveRecommendationResourceValidator()
        {
            /*RuleFor(m => m.ArticleId)
                .NotEmpty();

            RuleFor(m => m.UserId)
                .NotEmpty();*/

            RuleFor(m => m.Date)
                .NotEmpty();
        }
    }
}
