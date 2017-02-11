using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Domain.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
