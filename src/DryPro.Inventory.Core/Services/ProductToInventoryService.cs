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

        private static string GenerateName(ProductType type, ProductColor color) => $"{color} {type}";

        public Entities.Inventory Convert() => new()
        {
            Name = GenerateName(_product.Type, _product.Color),
            Description = _product.Description,
            StockItems = _product.StockItems,
            Cost = _product.Cost
        };
    }
}