using System.Threading.Tasks;

namespace DryPro.Inventory.Infrastructure.Repositories.Base
{
    public interface IRepositoryManager
    {
        IProductsRepository Products { get; }
        IPartsRepository Parts { get; }
        IInventoryRepository Inventory { get; }
        Task SaveAsync();
    }
}