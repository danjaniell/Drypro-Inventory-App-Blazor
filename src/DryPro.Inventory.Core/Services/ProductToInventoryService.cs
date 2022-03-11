using DryPro.Inventory.Core.Entities;
using DryPro.Inventory.Core.Services.Base;

namespace DryPro.Inventory.Core.Services
{
    public class ProductToInventoryService : IEntityConverter<Entities.Inventory>
    {
        private readonly Product _product;

        public ProductToInventoryService(Product product)
        {
            _product = product;
        }

        public Entities.Inventory Convert() => new()
        {
            Name = $"{_product.Color} {_product.Type}",
            Description = _product.Description,
            StockItems = _product.StockItems,
            Cost = _product.Cost
        };
    }
}