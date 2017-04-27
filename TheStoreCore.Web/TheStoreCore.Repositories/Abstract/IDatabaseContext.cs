using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheStoreCore.Web.TheStoreCore.Repositories.Abstract
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;

    }
}
