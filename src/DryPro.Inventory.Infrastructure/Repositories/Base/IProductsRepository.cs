using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryPro.Inventory.Core.Entities;

namespace DryPro.Inventory.Infrastructure.Repositories.Base
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(bool trackChanges);
        Task<Product> GetProductById(int id, bool trackChanges);
        Task CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}