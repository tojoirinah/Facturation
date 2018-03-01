using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
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
            List<TEntity> list;
            using (var session = NhibernateSession.OpenSession())
            {
                var dbQuery = session.Query<TEntity>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Fetch<TEntity, object>(navigationProperty));

                list = dbQuery.ToList<TEntity>();
            }
            return list;
        }

        public IList<TEntity> GetList(Func<TEntity, bool> @where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;
            using (var session = NhibernateSession.OpenSession())
            {
                var dbQuery = session.Query<TEntity>();
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Fetch<TEntity, object>(navigationProperty));
                list = dbQuery.Where(where).ToList<TEntity>();
            }
            return list;
        }

        public TEntity GetSingle(Func<TEntity, bool> @where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity item;
            using (var session = NhibernateSession.OpenSession())
            {
                var dbQuery = session.Query<TEntity>();
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Fetch<TEntity, object>(navigationProperty));
                item = dbQuery.FirstOrDefault(where);
            }
            return item;
        }

        public void Add(params TEntity[] items)
        {
            using (var session = NhibernateSession.OpenSession())
            {
                using (var transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    foreach (var item in items)
                    {
                        session.Save(item);
                    }
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
        }

        public void Update(params TEntity[] items)
        {
            using (var session = NhibernateSession.OpenSession())
            {
                using (var transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    foreach (var item in items)
                    {
                        session.SaveOrUpdate(item);
                    }
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
        }

        public void Remove(params TEntity[] items)
        {
            using (var session = NhibernateSession.OpenSession())
            {
                using (var transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    foreach (var item in items)
                    {
                        session.Delete(item);
                    }
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
        }
    }
}
