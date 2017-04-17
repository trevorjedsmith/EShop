using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheStoreCore.DAL.TheStoreCore.Repositories.Abstract
{
    public interface IDbSession
    {
        IDatabaseContext Current { get; }

        int SaveChanges();
    }
}
