using FluentValidation;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;

namespace GestionZapatillas.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator(IBrandRepository repository)
        {
            RuleFor(b => b.BrandName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Brand name is required")
                .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters")
                .Must((brand, name) => !repository.Exist(name, brand.BrandId == 0 ? null : brand.BrandId))
                    .WithMessage("Brand name already exists");

            RuleFor(b => b.Country)
                .NotEmpty().WithMessage("Country is required")
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters");
        }
    }
}
