using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Auctionata.Infra.Data.Context.Interfaces;

namespace Auctionata.Infra.Data.Common
{
    public abstract class Repository<TEntity, TContext>
         where TEntity : class
         where TContext : IDbContext, new()
    {
        protected Repository(IContextManager<TContext> contextManager)
        {
            Context = contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        protected IDbContext Context { get; }
        protected IDbSet<TEntity> DbSet { get; }

        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return DbSet.Remove(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
            return DbSet.Attach(entity);
        }

        public virtual TEntity Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            Context?.Dispose();
        }

        #endregion
    }
}