using CI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
namespace CI.Data.Models
{
    public class UnitOfWork : IDisposable
    {
        #region Private variables and constructor
        private readonly CIContext context;
        private CarRepository carRepository;
        private UserRepository userRepository;
        private bool disposed;
        #endregion

        #region Methods
        public UnitOfWork()
        {
            context = new CIContext(this);
        }

        public CarRepository CarRepository
        {
            get { return carRepository ?? (carRepository = new CarRepository(context, this)); }
        }

        public UserRepository UserRepository
        {
            get { return userRepository ?? (userRepository = new UserRepository(context, this)); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            return context.GetValidationErrors();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }
        #endregion
    }
}
