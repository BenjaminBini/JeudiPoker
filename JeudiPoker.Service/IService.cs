using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JeudiPoker.Service
{
    /// <summary>
    /// Interface for entity independent CRUD operations in services
    /// </summary>
    /// <typeparam name="T">Type of entity persisted</typeparam>
    public interface IService<T>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="includes">Include optional childs</param>
        /// <returns>Collection of results</returns>
        IEnumerable<T> Get(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get all and order by
        /// </summary>
        /// <param name="orderBy">Field to sort on</param>
        /// <param name="includes">Include optional childs</param>
        /// <returns>Collection of results</returns>
        IEnumerable<T> Get(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get many with filter and order by
        /// </summary>
        /// <param name="filter">Filters to apply</param>
        /// <param name="orderBy">Field to sort on</param>
        /// <param name="includes">Include optional childs</param>
        /// <returns>Collection of results</returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get one by filter
        /// </summary>
        /// <param name="filter">Filters to apply</param>
        /// <param name="includes">Include optional childs</param>
        /// <returns>Result of the query</returns>
        T GetOne(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Create one entity
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Update one entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Deleted entity</param>
        void Delete(T entity);

        /// <summary>
        /// Delete by filter
        /// </summary>
        /// <param name="filter">Filter the entities to delete</param>
        void Delete(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Commit changes to database
        /// </summary>
        void Commit();
    }
}