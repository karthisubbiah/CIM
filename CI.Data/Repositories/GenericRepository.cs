using CI.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
namespace CI.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        #region variables
        protected readonly CIContext dbContext;
        protected readonly DbSet<T> dbSet;
        protected readonly UnitOfWork unitOfWork;
        #endregion

        #region Methods
        internal GenericRepository(CIContext context, UnitOfWork unitOfWork)
        {
            dbContext = context;
            dbSet = context.Set<T>();
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<T> All()
        {
            return from entity in dbSet select entity;
        }

        virtual public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        virtual public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsQueryable().Where(predicate);
        }

        virtual public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        virtual public void Update(T entity)
        {
            var entry = dbContext.Entry(entity);

            entry.State = EntityState.Modified;
            entry.CurrentValues.SetValues(entity);
        }

        virtual public void Delete(int id)
        {
            Delete(FindById(id));
        }

        private void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        #endregion
        
    }
}
