using FluentValidation;
using UI_MVC.ViewModels;

namespace UI_MVC.Validators
{
    public class AlbumViewModelValidator : AbstractValidator<AlbumViewModel>
    {
        public AlbumViewModelValidator()
        {
            RuleFor(a => a.Album.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(a => a.Album.Name).MinimumLength(2).WithMessage("Name must consist of at least two characters.");
            //RuleFor(a => a.Album.ReleaseDate).NotEmpty().WithMessage("Date is required.");
        }
    }
}