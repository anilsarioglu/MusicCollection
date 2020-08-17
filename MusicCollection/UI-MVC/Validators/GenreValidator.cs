using FluentValidation;
using Shared;

namespace UI_MVC.Validators
{
    public class GenreValidator : AbstractValidator<GenreDto>
    {
        public GenreValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(g => g.Name).MinimumLength(2).WithMessage("Name must consist of at least two characters.");
        }
    }
}