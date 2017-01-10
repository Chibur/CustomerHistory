using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Domain.Custom
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T newEntity);
        void Remove(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll();
        T FindById(int id);
    }
}
