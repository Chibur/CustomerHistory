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
    public class AccountRepository: IRepository<Account>
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

        public IEnumerable<Account> FindAll()
        {
            return _context.Accounts.AsNoTracking();
        }

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Accounts.Remove(_context.Accounts.Find(id));
            _context.SaveChanges();
        }
    }

}
