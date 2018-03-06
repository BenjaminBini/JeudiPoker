using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JeudiPoker.Data.Infrastructure;

namespace JeudiPoker.Service
{
    /// <summary>
    /// Interface for entity independent CRUD operations in services
    /// </summary>
    /// <typeparam name="T">Type of entity persisted</typeparam>
    public class ServiceBase<T> : IService<T> where T : class
    {
        protected IRepository<T> Repository;
        protected IUnitOfWork UnitOfWork;

        protected ServiceBase(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            return Repository.Get(includes);
        }

        public IEnumerable<T> Get(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            return Repository.Get(orderBy, includes);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            return Repository.Get(filter, orderBy, includes);
        }

        public T GetOne(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            return Repository.GetOne(filter, includes);
        }

        public void Create(T entity)
        {
            Repository.Create(entity);
        }

        public void Update(T entity)
        {
            Repository.Update(entity);
        }

        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            Repository.Delete(filter);
        }

        public void Commit()
        {
            UnitOfWork.Commit();
        }
    }
}