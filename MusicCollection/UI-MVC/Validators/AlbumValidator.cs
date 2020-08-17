using System;
using FluentValidation;
using Shared;

namespace UI_MVC.Validators
{
    public class AlbumValidator : AbstractValidator<AlbumDto>
    {
        public AlbumValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(a => a.Name).MinimumLength(2).WithMessage("Name must consist of at least two characters.");
            RuleFor(a => a.ReleaseDate).NotEmpty().WithMessage("Date is required.");
            RuleFor(a => a.ReleaseDate).Must(BeAValidDate).WithMessage("Date is not valid.");
            RuleFor(a => a.ReleaseDate).LessThanOrEqualTo(DateTime.Today).WithMessage("Date is not valid.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}