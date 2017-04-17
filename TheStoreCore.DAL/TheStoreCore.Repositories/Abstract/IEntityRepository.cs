using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheStoreCore.DAL.TheStoreCore.Entities.Core;

namespace TheStoreCore.DAL.TheStoreCore.Repositories.Abstract
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindAll();

        T FindById(int id);

        bool Exists(int id);

        void Commit();
    }
}
