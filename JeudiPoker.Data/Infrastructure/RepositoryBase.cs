using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace JeudiPoker.Data.Infrastructure
{
    /// <summary>
    /// Basic CRUD methods for all entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> _dbSet;

        private PokerDbContext _dbContext;

        protected IDbFactory DbFactory { get; }

        protected PokerDbContext DbContext => _dbContext ?? (_dbContext = DbFactory.Init());

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public IEnumerable<T> Get(
            params Expression<Func<T, object>>[] includes)
        {
            return Get(null, null, includes);
        }

        public IEnumerable<T> Get(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            return Get(null, orderBy, includes);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            // Equivalent à :
            //
            // IQueryable<T> query = _dbSet;
            // foreach (Expression<Func<T, object>> include in includes)
            //   query = query.Include(include);
            var query = includes.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(_dbSet,
                (current, include) => current.Include(include));

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual T GetOne(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(where);
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.FirstOrDefault();
        }

        public virtual void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> filter)
        {
            var entities = _dbSet.Where(filter).AsEnumerable();
            foreach (var entity in entities)
                _dbSet.Remove(entity);
        }
    }
}