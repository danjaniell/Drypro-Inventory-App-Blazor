using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryPro.Inventory.Core.Entities;
using DryPro.Inventory.Infrastructure.DbContexts;
using DryPro.Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DryPro.Inventory.Infrastructure.Repositories
{
    public class PartsRepository : RepositoryBase<Parts>, IPartsRepository
    {
        public PartsRepository(InventoryDbContext context) : base(context)
        {
        }

        public async Task CreateParts(Parts part) => await Create(part);

        public void DeleteParts(Parts part) => Delete(part);

        public async Task<IEnumerable<Parts>> GetAllParts(bool trackChanges) => await FindAll(trackChanges).OrderByDescending(x => x.ModifiedAt).ToListAsync();

        public async Task<Parts> GetPartById(int id, bool trackChanges) => await FindByCondition((x) => x.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateParts(Parts part) => Update(part);
    }
}