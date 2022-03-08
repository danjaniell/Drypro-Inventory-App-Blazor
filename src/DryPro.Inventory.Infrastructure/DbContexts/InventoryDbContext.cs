using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryPro.Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DryPro.Inventory.Infrastructure.DbContexts
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
