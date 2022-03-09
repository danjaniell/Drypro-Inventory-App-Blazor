using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryPro.Inventory.Core.Entities;
using DryPro.Inventory.Infrastructure.DbContexts;
using DryPro.Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DryPro.Inventory.Infrastructure.Repositories
{
    public class ProductsRepository : RepositoryBase<Product>, IProductsRepository
    {
        public ProductsRepository(InventoryDbContext context) : base(context)
        {
        }

        public async Task CreateProduct(Product product) => await Create(product);

        public void DeleteProduct(Product product) => Delete(product);

        public async Task<IEnumerable<Product>> GetAllProducts(bool trackChanges) => await FindAll(trackChanges).OrderByDescending(x => x.ModifiedAt).ToListAsync();

        public async Task<Product> GetProductById(int id, bool trackChanges) => await FindByCondition((x) => x.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateProduct(Product product) => Update(product);
    }
}