using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Data.Repositories;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Data.Mappers;
using CustomerPayments;

namespace CustomerPayments.Data.Repositories
{
    public class TransactionRepository
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
            return _context.Transactions.AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
        }

        public Transaction Find(int id, int accountId)
        {
            return _context.Transactions.AsNoTracking()
                .FirstOrDefault(t => t.AccountId == accountId && t.Id == id);
        }
        public IEnumerable<Transaction> FindAll()
        {
            return _context.Transactions.AsNoTracking();
        }

        public IEnumerable<Transaction> FindAll(int accountId)
        {
            return _context.Transactions.AsNoTracking()
                .Where(t => t.AccountId == accountId);
        }
        public RepositoryActionResult<Transaction> Add(Transaction transaction)
        {
            try
            {
                _context.Transactions.Add(transaction);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Transaction>(transaction, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Transaction>(transaction, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Transaction>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<Transaction> Update(Transaction transaction)
        {
            try
            {
                _context.Entry(transaction).State = EntityState.Modified;
                var excistingTransaction = _context.Transactions.FirstOrDefault(a => a.Id == transaction.Id);

                if (excistingTransaction == null)
                {
                    return new RepositoryActionResult<Transaction>(transaction, RepositoryActionStatus.NotFound);
                }
                _context.Entry(transaction).State = EntityState.Detached;
                _context.Transactions.Attach(transaction);
                _context.Entry(transaction).State = EntityState.Modified;
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Transaction>(transaction, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Transaction>(transaction, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Transaction>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<Transaction> Remove(int id)
        {
            try
            {
                var transaction = _context.Transactions.Where(e => e.Id == id).FirstOrDefault();
                if (transaction != null)
                {
                    _context.Transactions.Remove(transaction);
                    _context.SaveChanges();
                    return new RepositoryActionResult<Transaction>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<Transaction>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Transaction>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}