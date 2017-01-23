using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Data.Repositories;
using CustomerPayments.Domain.Interfaces;
using System.Linq.Expressions;

namespace CustomerPayments.Data.Repositories
{
    public class GenericRepository<T> where T: class, IEntity
    {
        private readonly CustomerPaymentsContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CustomerPaymentsContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> FindAll()
        {
            return _dbSet.AsNoTracking().ToList();          
        }

        public T FindById(int id)
        {
            return _dbSet.AsNoTracking().SingleOrDefault(t=> t.Id == id);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> results = _dbSet.AsNoTracking()
              .Where(predicate).ToList();
            return results;
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = FindById(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

    }
}
