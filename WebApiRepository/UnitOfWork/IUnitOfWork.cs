using System;
using WebApiRepository.Repository;

namespace WebApiRepository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}