using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryPro.Inventory.Core.Entities;

namespace DryPro.Inventory.Infrastructure.Repositories.Base
{
    public interface IPartsRepository
    {
        Task<IEnumerable<Parts>> GetAllParts(bool trackChanges);
        Task<Parts> GetPartById(int id, bool trackChanges);
        Task CreateParts(Parts product);
        void UpdateParts(Parts product);
        void DeleteParts(Parts product);
    }
}