using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace prboard.api.data.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IUuid, new()
    {
        public Type ElementType => Queryable.ElementType;

        public Expression Expression => Queryable.Expression;

        public IQueryProvider Provider => Queryable.Provider;

        public IQueryable<TEntity> Queryable => Set.AsQueryable();


        private DbSet<TEntity> Set { get; }


        public Repository(DbContext context)
        {
            Set = context.Set<TEntity>();
        }

        public TEntity Create()
        {
            var entity = new TEntity {Uuid = Guid.NewGuid()};

            Set.Add(entity);

            return entity;
        }

        public TEntity Attach(TEntity entity)
        {
            Set.Attach(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            Set.Remove(entity);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}