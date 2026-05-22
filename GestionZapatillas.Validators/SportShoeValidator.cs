using FluentValidation;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;

namespace GestionZapatillas.Validators
{
    public class SportShoeValidator : AbstractValidator<SportShoe>
    {
        public SportShoeValidator(ISportShoeRepository repository)
        {
            RuleFor(ss => ss.Model)
                .NotEmpty().WithMessage("Model is required")
                .MaximumLength(150).WithMessage("Model must not exceed 150 characters");

            RuleFor(ss => ss.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(ss => ss.BrandId)
                .GreaterThan(0).WithMessage("Brand is required");

            RuleFor(ss => ss.SportId)
                .GreaterThan(0).WithMessage("Sport is required");

           
            RuleFor(ss => ss.GenreId)
                .GreaterThan(0).WithMessage("Genre is required");

         
            RuleFor(ss => ss.ShoeSizes)
                .NotEmpty().WithMessage("At least one size is required");

            
            RuleFor(ss => ss)
                .Must(shoe => !HasDuplicateSize(shoe, repository))
                .WithMessage("A shoe with the same model, brand and size already exists")
                .When(ss => !string.IsNullOrWhiteSpace(ss.Model)
                            && ss.BrandId > 0
                            && ss.ShoeSizes != null
                            && ss.ShoeSizes.Any());
        }

        private static bool HasDuplicateSize(SportShoe shoe, ISportShoeRepository repository)
        {
            foreach (var size in shoe.ShoeSizes)
            {
                var excludeId = shoe.ShoeId == 0 ? (int?)null : shoe.ShoeId;
                if (repository.Exist(shoe.Model, shoe.BrandId, size.SizeId, excludeId))
                    return true;
            }
            return false;
        }
    }
}
