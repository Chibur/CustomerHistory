using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Custom;

namespace CustomerPayments.Data.Custom
{
    public class SqlRepository<T> : IRepository<T>
                                    where T :class, IEntity
    {
        protected DbSet<T> _objectSet;
        public SqlRepository(CustomerPaymentsContext contex)
        {
            _objectSet = contex.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }
        public void Add(T newEntity)
        {
            _objectSet.AddObject(newEntity);
        }
        public void Remove(T entity)
        {
            _objectSet.DeleteObject(entity);
        }
        public IQueryable<T> FindAll()
        {
            return _objectSet;
        }
        public T FindById(int id)
        {
            return _objectSet.Single(o => o.Id == id);
        }
    }
}
