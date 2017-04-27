using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Entities.Core;
using TheStoreCore.Web.TheStoreCore.Repositories.Abstract;

namespace TheStoreCore.Web.TheStoreCore.Repositories.Concrete
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        public IDbSession DbSession { get; private set; }

        private DbSet<T> DbSet { get; set; }

        public EntityRepository(IDbSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            DbSession = session;
            DbSet = session.Current.GetDbSet<T>();
        }

        public void Create(T entity)
        {
            EntityEntry dbEntityEntry = ((DbContext)DbSession.Current).Entry(entity);

            //if entity is not being tracked
            if (dbEntityEntry.State != EntityState.Detached)
            {
                //track entity
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                //add entity to context
                DbSet.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = ((DbContext)DbSession.Current).Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = FindById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public bool Exists(int id)
        {
            return DbSet.AsNoTracking().Count(o => o.Id == id) > 0;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return DbSet;
        }

        public T FindById(int id)
        {
            return DbSet.FirstOrDefault(o => o.Id == id);
        }

        public void Update(T entity)
        {
            EntityEntry dbEntityEntry = ((DbContext)DbSession.Current).Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Commit()
        {
            DbSession.SaveChanges();
        }
    }
}
