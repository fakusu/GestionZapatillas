using FluentValidation;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;

namespace GestionZapatillas.Validators
{
    public class SportValidator : AbstractValidator<Sport>
    {
        public SportValidator(ISportRepository repository)
        {
            RuleFor(s => s.SportName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Sport name is required")
                .MaximumLength(20).WithMessage("Sport name must not exceed 20 characters")
                .Must((sport, name) => !repository.Exist(name, sport.SportId == 0 ? null : sport.SportId))
                    .WithMessage("Sport name already exists");
        }
    }
}
