using System.Threading.Tasks;
using DryPro.Inventory.Infrastructure.DbContexts;
using DryPro.Inventory.Infrastructure.Repositories.Base;

namespace DryPro.Inventory.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly InventoryDbContext _context;
        private IProductsRepository _productsRepository;

        public RepositoryManager(InventoryDbContext context)
        {
            _context = context;
        }

        public IProductsRepository Products => _productsRepository ??= new ProductsRepository(_context);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}