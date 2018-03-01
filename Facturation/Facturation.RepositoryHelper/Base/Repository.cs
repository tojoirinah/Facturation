using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Facturation.RepositoryHelper.Base
{
    public interface IGenericRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    { 
        IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);
        IList<TEntity> GetList(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        TEntity GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        void Add(params TEntity[] items);
        void Update(params TEntity[] items);
        void Remove(params TEntity[] itemss);
    }

    public class GenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        public IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list = null;
            return list;
        }

        public IList<TEntity> GetList(Func<TEntity, bool> @where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list = null; 
            return list;
        }

        public TEntity GetSingle(Func<TEntity, bool> @where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity item = null;
            return item;
        }

        public void Add(params TEntity[] items)
        {

        }

        public void Update(params TEntity[] items)
        {
        }

        public void Remove(params TEntity[] items)
        {
        }
    }
}
