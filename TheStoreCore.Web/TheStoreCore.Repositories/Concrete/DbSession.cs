using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Repositories.Abstract;

namespace TheStoreCore.Web.TheStoreCore.Repositories.Concrete
{
    public class DbSession : IDbSession
    {
        private IDatabaseContext _context;

        public DbSession(IDatabaseContext context)
        {
            _context = context;
        }

        public IDatabaseContext Current
        {
            get
            {
                return this._context;
            }
        }

        public int SaveChanges()
        {
            return ((DbContext)Current).SaveChanges();
        }
    
    }
}
