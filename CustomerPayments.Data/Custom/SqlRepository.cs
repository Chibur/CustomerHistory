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
        protected CustomerPaymentsContext _context;
        protected DbSet<T> _dbSet;
        
        public SqlRepository(CustomerPaymentsContext contex)
        {
            _context = contex;
            _dbSet = contex.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public void Add(T newEntity)
        {
            _dbSet.Add(newEntity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public IQueryable<T> FindAll()
        {
            return _dbSet;
        }
        public T FindById(int id)
        {
            return _dbSet.Single(o => o.Id == id);
        }
    }
}
