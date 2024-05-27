using FluentValidation;
using SocialNetwork.Api.Resources;

namespace SocialNetwork.Api.Validators
{
    public class SaveArticleResourceValidator : AbstractValidator<SaveArticleResource>
    {
        public SaveArticleResourceValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .MaximumLength(200); // Longitud máxima del artículo

            RuleFor(m => m.Content)
                .NotEmpty();

            RuleFor(m => m.TypeTopicId)
                .NotEmpty()
                .WithMessage("'TypeTopicId' must not be 0.");

            RuleFor(m => m.UserId)
                .NotEmpty()
                .WithMessage("'UserId' must not be 0.");

        }
    }
}
