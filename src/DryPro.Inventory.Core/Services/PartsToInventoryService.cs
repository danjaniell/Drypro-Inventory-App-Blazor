using DryPro.Inventory.Core.Entities;
using DryPro.Inventory.Core.Services.Base;

namespace DryPro.Inventory.Core.Services
{
    public class PartsToInventoryService : IEntityConverter<Entities.Inventory>
    {
        private readonly Parts _parts;

        public PartsToInventoryService(Parts product)
        {
            _parts = product;
        }

        public Entities.Inventory Convert() => new()
        {
            Name = _parts.Name,
            Description = _parts.Description,
            StockItems = _parts.StockItems,
            Cost = _parts.Cost
        };
    }
}