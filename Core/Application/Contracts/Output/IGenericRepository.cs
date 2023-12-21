using Ardalis.Specification;
using Domain.Entities;

namespace Application.Contracts.Output
{
    public interface IGenericRepository<TEntity> : IRepositoryBase<TEntity> where TEntity: Entity
    {
    }
}
