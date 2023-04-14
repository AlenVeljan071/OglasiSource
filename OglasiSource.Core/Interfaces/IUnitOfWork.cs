
using Microsoft.EntityFrameworkCore.Storage;
using OglasiSource.Core.Entities;


namespace OglasiSource.Core.Interfaces
{


    public interface IUnitOfWork : IDisposable
        {
            IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity;
            Task<int> Complete();
            Task<IDbContextTransaction> BeginTransactionAsync();
    }
    
}
