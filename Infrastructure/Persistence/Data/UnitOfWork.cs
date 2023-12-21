using Application.Contracts.Output;
using Domain.Entities;

namespace Persistence.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private Dictionary<object, object> _repositories = new Dictionary<object, object>();
        private readonly AppDbContext _appDbContext;

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            var repoType = typeof(TEntity);

            if(_repositories.ContainsKey(repoType))
            {
                return (IGenericRepository<TEntity>)_repositories[repoType];
            }
                
            var newRepo = Activator.CreateInstance(typeof(GenericRepository<>).MakeGenericType(typeof(TEntity)), _appDbContext);

            return (IGenericRepository<TEntity>)newRepo;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _appDbContext.Database.RollbackTransactionAsync(cancellationToken);
        }
    }
}
