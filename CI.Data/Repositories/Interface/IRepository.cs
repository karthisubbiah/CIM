using System;
using System.Linq;
using System.Linq.Expressions;

namespace CI.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        T FindById(int id);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
