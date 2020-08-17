using System;
using FluentValidation;
using Shared;

namespace UI_MVC.Validators
{
    public class ArtistValidator : AbstractValidator<ArtistDto>
    {
        public ArtistValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(a => a.Name).MinimumLength(2).WithMessage("Name must consist of at least two characters.");
            RuleFor(a => a.Birthdate).NotEmpty().WithMessage("Date is required.");
            RuleFor(a => a.Birthdate).Must(BeAValidDate).WithMessage("Date is not valid.");
            RuleFor(a => a.Birthdate).LessThanOrEqualTo(DateTime.Today).WithMessage("Date is not valid.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}