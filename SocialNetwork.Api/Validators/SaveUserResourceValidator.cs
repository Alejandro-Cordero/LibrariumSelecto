using FluentValidation;
using SocialNetwork.Api.Resources;

namespace SocialNetwork.Api.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(m => m.Login)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.Password)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.Email)
                .NotEmpty()
                .MaximumLength(100);

            //TODO: Add other rules

            //RuleFor(m => m.TypeGenderId)
            //    .NotEmpty()
            //    .WithMessage("'Type Gender Id' must not be 0.");
        }
    }
}