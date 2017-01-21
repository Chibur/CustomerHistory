using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Data.Repositories
{
    public interface IRepository<T> 
    {
        IEnumerable<T> FindAll();
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
