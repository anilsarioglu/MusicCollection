using System;
using FluentValidation;
using Shared;
using UI_MVC.Validators.Rules;

namespace UI_MVC.Validators
{
    public class ArtistValidator : AbstractValidator<ArtistDto>
    {
        public ArtistValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(a => a.Name).MinimumLength(2).WithMessage("Name must consist of at least two characters.");
            RuleFor(a => a.Birthdate).NotEmpty().WithMessage("Date is required.");
            RuleFor(a => a.Birthdate).Must(CustomRules.BeAValidDate).WithMessage("Date is not valid.");
            RuleFor(a => a.Birthdate).LessThanOrEqualTo(DateTime.Today).WithMessage("Date must be today or before today.");
        }
    }
}