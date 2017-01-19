using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All();
        IEnumerable<T> AllInclude(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindByInclude
            (Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindByKey(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
