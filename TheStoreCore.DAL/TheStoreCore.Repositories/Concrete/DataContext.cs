using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.DAL.TheStoreCore.Entities.App;
using TheStoreCore.DAL.TheStoreCore.Repositories.Abstract;

namespace TheStoreCore.DAL.TheStoreCore.Repositories.Concrete
{
    public class DataContext : DbContext, IDatabaseContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> Lines { get; set; }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }
}
