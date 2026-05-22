using FluentValidation;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;

namespace GestionZapatillas.Validators
{
    public class SizeValidator : AbstractValidator<Size>
    {
        public SizeValidator(ISizeRepository repository)
        {
            RuleFor(s => s.SizeNumber)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("Size must be greater than 0")
                .Must((size, number) => !repository.Exist(number, size.SizeId == 0 ? null : size.SizeId))
                    .WithMessage("Size already exists");
        }
    }
}
