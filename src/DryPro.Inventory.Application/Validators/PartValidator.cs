using DryPro.Inventory.Core.Entities;
using FluentValidation;

namespace DryPro.Inventory.Application.Validators
{
    public class PartValidator : AbstractValidator<Parts>
    {
        public PartValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(55);
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(255);
            RuleFor(x => x.StockItems).GreaterThanOrEqualTo(0).WithMessage("Cannot be negative");
        }
    }
}