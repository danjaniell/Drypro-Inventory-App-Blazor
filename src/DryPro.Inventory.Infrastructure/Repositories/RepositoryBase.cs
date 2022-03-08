using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DryPro.Inventory.Infrastructure.DbContexts;
using DryPro.Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DryPro.Inventory.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly InventoryDbContext _context;

        public RepositoryBase(InventoryDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (trackChanges) { return _context.Set<T>(); }

            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges) { return _context.Set<T>().Where(expression); }

            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}