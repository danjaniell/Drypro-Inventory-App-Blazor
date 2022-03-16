using System.Collections.Generic;
using System.Threading.Tasks;

namespace DryPro.Inventory.Infrastructure.Repositories.Base
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Core.Entities.Inventory>> GetAllItems(bool trackChanges);
        Task<Core.Entities.Inventory> GetItemById(int id, bool trackChanges);
        Task CreateItem(Core.Entities.Inventory item);
        void UpdateItem(Core.Entities.Inventory item);
        void DeleteItem(Core.Entities.Inventory item);
    }
}