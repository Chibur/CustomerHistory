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
    public class AccountRepository
    {
        private readonly CustomerPaymentsContext _context;
        public AccountRepository()
        {
            _context = new CustomerPaymentsContext();
        }
        public AccountRepository(CustomerPaymentsContext context)
        {
            _context = context;
        }

        public  Account Find(int id)
        {
            var account = _context.Accounts.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return account;
        }
        public Account Find(int id, int customerId)
        {
            return _context.Accounts.AsNoTracking()
                .FirstOrDefault(a => a.CustomerId == customerId && a.Id == id);
        }
        public IEnumerable<Account> FindAll()
        {
            return _context.Accounts.AsNoTracking();
        }

        public IEnumerable<Account> FindAll(int customerId)
        {
            return _context.Accounts.AsNoTracking()
                .Where(a => a.CustomerId == customerId);
        }

        public RepositoryActionResult<Account> Add(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Account>(null, RepositoryActionStatus.Error, ex);
            }
           
        }

        public RepositoryActionResult<Account> Update(Account account)
        {
            try
            {
                _context.Entry(account).State = EntityState.Modified;
                var existingAccount = _context.Accounts.FirstOrDefault(a => a.Id == account.Id);
               
                if (existingAccount == null)
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.NotFound);
                }
                _context.Entry(account).State = EntityState.Detached;
                _context.Accounts.Attach(account);
                _context.Entry(account).State = EntityState.Modified;
                var result = _context.SaveChanges();
                if(result>0)
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Account>(null, RepositoryActionStatus.Error, ex);
            }
           
        }

        public RepositoryActionResult<Account> Remove(int id)
        {
            try
            {
                var account = _context.Accounts.Where(e => e.Id == id).FirstOrDefault();
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                    _context.SaveChanges();
                    return new RepositoryActionResult<Account>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<Account>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Account>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }

}
