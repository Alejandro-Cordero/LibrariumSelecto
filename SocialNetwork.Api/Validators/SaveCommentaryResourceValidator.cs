using FluentValidation;
using SocialNetwork.Api.Resources;

namespace SocialNetwork.Api.Validators
{
    public class SaveCommentaryResourceValidator : AbstractValidator<SaveCommentaryResource>
    {
        public SaveCommentaryResourceValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.Description)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(m => m.Rating)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(5);

            RuleFor(m => m.Date)
                .NotEmpty();

        }
    }
}
