using Domain.Entities;

namespace Application.Contracts.Output
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
