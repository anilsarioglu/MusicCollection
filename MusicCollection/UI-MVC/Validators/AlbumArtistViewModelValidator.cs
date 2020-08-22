using System;
using FluentValidation;
using UI_MVC.Validators.Rules;
using UI_MVC.ViewModels;

namespace UI_MVC.Validators
{
    public class AlbumArtistViewModelValidator : AbstractValidator<AlbumArtistViewModel>
    {
        public AlbumArtistViewModelValidator()
        {
            RuleFor(a => a.Album.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(a => a.Album.Name).MinimumLength(2).WithMessage("Name must consist of at least two characters.");
            RuleFor(a => a.Album.ReleaseDate).NotEmpty().WithMessage("Date is required.");
            RuleFor(a => a.Album.ReleaseDate).Must(CustomRules.BeAValidDate).WithMessage("Date is not valid.");
            RuleFor(a => a.Album.ReleaseDate).LessThanOrEqualTo(DateTime.Today).WithMessage("Date must be today or before today.");
        }
    }
}