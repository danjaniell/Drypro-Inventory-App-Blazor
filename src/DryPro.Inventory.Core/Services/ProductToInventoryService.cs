using DryPro.Inventory.Core.Entities;
using DryPro.Inventory.Core.Services.Base;

namespace DryPro.Inventory.Core.Services
{
    public class ProductToInventoryService : IEntityConverter<Entities.Inventory>
    {
        private readonly Product _parts;

        public ProductToInventoryService(Product product)
        {
            _parts = product;
        }

        private static string GenerateName(ProductType type, ProductColor color) => $"{color} {type}";

        public Entities.Inventory Convert() => new()
        {
            Name = GenerateName(_parts.Type, _parts.Color),
            Description = _parts.Description,
            StockItems = _parts.StockItems,
            Cost = 0
        };
    }
}