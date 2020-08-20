using FluentValidation;
using Shared;

namespace UI_MVC.Validators
{
    public class TrackValidator : AbstractValidator<TrackDto>
    {
        public TrackValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(t => t.Title).MinimumLength(2).WithMessage("Title must consist of at least two characters.");
            RuleFor(t => t.Duration).NotEmpty().WithMessage("Duration is required.");
            RuleFor(t => t.Duration);
            RuleFor(t => t.Duration).LessThanOrEqualTo(9999).WithMessage("Duration must be shorter than 9999 seconds.");
            RuleFor(t => t.Label).NotEmpty().WithMessage("Label is required.");
            RuleFor(t => t.Label).MinimumLength(2).WithMessage("Label must consist of at least two characters.");
        }
    }
}