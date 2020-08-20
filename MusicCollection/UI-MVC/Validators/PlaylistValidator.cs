using FluentValidation;
using Shared;

namespace UI_MVC.Validators
{
    public class PlaylistValidator : AbstractValidator<PlaylistDto>
    {
        public PlaylistValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required.");
        }
    }
}