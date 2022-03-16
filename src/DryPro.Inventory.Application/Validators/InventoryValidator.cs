using FluentValidation;

namespace DryPro.Inventory.Application.Validators
{
    public class InventoryValidator : AbstractValidator<Core.Entities.Inventory>
    {
        public InventoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(55);
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(255);
            RuleFor(x => x.StockItems).GreaterThanOrEqualTo(0).WithMessage("Cannot be negative");
            RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).WithMessage("Cannot be negative");
        }
    }
}