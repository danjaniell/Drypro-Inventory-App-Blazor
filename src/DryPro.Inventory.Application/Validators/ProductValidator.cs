using DryPro.Inventory.Core.Entities;
using FluentValidation;

namespace DryPro.Inventory.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(255);
            RuleFor(x => x.StockItems).GreaterThanOrEqualTo(0).WithMessage("Cannot be negative");
        }
    }
}