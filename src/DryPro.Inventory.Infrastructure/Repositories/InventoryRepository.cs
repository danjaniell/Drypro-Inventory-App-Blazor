using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryPro.Inventory.Infrastructure.DbContexts;
using DryPro.Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DryPro.Inventory.Infrastructure.Repositories
{
    public class InventoryRepository : RepositoryBase<Core.Entities.Inventory>, IInventoryRepository
    {
        public InventoryRepository(InventoryDbContext context) : base(context)
        {
        }

        public async Task CreateItem(Core.Entities.Inventory item) => await Create(item);

        public void DeleteItem(Core.Entities.Inventory item) => Delete(item);

        public async Task<IEnumerable<Core.Entities.Inventory>> GetAllItems(bool trackChanges) => await FindAll(trackChanges).OrderByDescending(x => x.ModifiedAt).ToListAsync();

        public async Task<Core.Entities.Inventory> GetItemById(int id, bool trackChanges) => await FindByCondition((x) => x.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateItem(Core.Entities.Inventory item) => Update(item);
    }
}