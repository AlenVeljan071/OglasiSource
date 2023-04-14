using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Interfaces;
using OglasiSource.Infrastructure.Data.Context;
using OglasiSource.Infrastructure.Data.Repository;

namespace OglasiSource.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbWriteContext _writeContext;
        private Hashtable? _repositories;
        public UnitOfWork(DbWriteContext writeContext)
        {
            _writeContext = writeContext;
        }

        public async Task<int> Complete()
        {
            return await _writeContext.SaveChangesAsync();

        }

        public void Dispose()
        {

            _writeContext.Dispose();
        }

        public IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _writeContext);

                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IGenericRepository<TEntity>;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _writeContext.Database.BeginTransactionAsync();
        }

    }
}
