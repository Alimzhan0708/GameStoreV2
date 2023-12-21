using Application.Contracts.Output;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Data
{
    internal class GenericRepository<TEntity> : RepositoryBase<TEntity>, IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        void AddEntityWithoutSave(TEntity entity)
        {
            _appDbContext.Add(entity);
        }
    }
}
