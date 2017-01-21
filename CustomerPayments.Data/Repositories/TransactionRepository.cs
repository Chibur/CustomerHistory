using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Data.Mappers;
using CustomerPayments;

namespace CustomerPayments.Data.Repositories
{
    public class TransactionRepository: IRepository<Transaction>
    {
        private readonly CustomerPaymentsContext _context;
        public TransactionRepository()
        {
            _context = new CustomerPaymentsContext();
        }
        public TransactionRepository(CustomerPaymentsContext context)
        {
            _context = context;
        }

        public Transaction Find(int id)
        {
            var transaction = _context.Transactions.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return transaction;
        }

        public IEnumerable<Transaction> FindAll()
        {
            return _context.Transactions.AsNoTracking();
        }

        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void Update(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Transactions.Remove(_context.Transactions.Find(id));
            _context.SaveChanges();
        }
    }
}