using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace foundation.Entities.Contracts
{
    public interface IRepository<TEntity> : IIncludableQueryable<TEntity, bool> where TEntity : IUuid, new()
    {
        IQueryable<TEntity> Queryable { get; }

        TEntity Create();

        TEntity Attach(TEntity entity);

        void Delete(TEntity entity);
    }
}