using FluentValidation;
using UI_MVC.ViewModels;

namespace UI_MVC.Validators
{
    public class TrackGenreViewModelValidator : AbstractValidator<TrackGenreViewModel>
    {
        public TrackGenreViewModelValidator()
        {
            RuleFor(t => t.Track.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(t => t.Track.Title).MinimumLength(2).WithMessage("Title must consist of at least two characters.");
            RuleFor(t => t.Track.Duration).NotEmpty().WithMessage("Duration is required.");
            RuleFor(t => t.Track.Duration).LessThanOrEqualTo(9999).WithMessage("Duration must be shorter than 9999 seconds.");
            RuleFor(t => t.Track.Label).NotEmpty().WithMessage("Label is required.");
            RuleFor(t => t.Track.Label).MinimumLength(2).WithMessage("Label must consist of at least two characters.");
        }
    }
}