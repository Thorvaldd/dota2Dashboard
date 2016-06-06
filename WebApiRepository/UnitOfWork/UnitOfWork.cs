using System;
using System.Collections.Concurrent;
using WebApiRepository.Repository;

namespace WebApiRepository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields & constructor

        private bool _disposed;
        private readonly SqlLiteContext _context;
        private ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork()
        {
            _context = new SqlLiteContext();
        }
        #endregion


       

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new ConcurrentDictionary<string, object>();
            }

            var type = typeof (T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof (GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof (T)), _context);

                _repositories.GetOrAdd(type, repositoryInstance);
            }
            return (GenericRepository<T>) _repositories[type];
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        #region Dispose

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
           Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
