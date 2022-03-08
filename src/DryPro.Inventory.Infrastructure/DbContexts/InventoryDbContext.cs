using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DryPro.Inventory.Core.Entities;
using DryPro.Inventory.Core.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace DryPro.Inventory.Infrastructure.DbContexts
{
    public class InventoryDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Product> Products { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is BaseTransactionModel &&
                                                  (e.State == EntityState.Added ||
                                                   e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var utcNow = DateTime.UtcNow;
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseTransactionModel)entityEntry.Entity).CreatedAt = utcNow;
                    ((BaseTransactionModel)entityEntry.Entity).CreatedBy = _currentUserService.UserId;
                }
                else
                {
                    Entry((BaseTransactionModel)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    Entry((BaseTransactionModel)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                ((BaseTransactionModel)entityEntry.Entity).ModifiedAt = utcNow;
                ((BaseTransactionModel)entityEntry.Entity).ModifiedBy = _currentUserService.UserId;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
