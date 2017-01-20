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

        public DTO.Transaction FindTransaction(int id)
        {
            var account = _context.Transactions.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return AccountMapper.MapAccount(account);
        }

        public IEnumerable<DTO.Transaction> FindAll()
        {
            return _context.Transactions.AsNoTracking()
                .Select(c => AccountMapper.MapAccount(c));
        }

        public void Add(DTO.Transaction transaction)
        {
            _context.Transactions.Add(
                TransactionMapper.MapTransaction(transaction));
            _context.SaveChanges();
        }

        public void Update(DTO.Account transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveAccount(int id)
        {
            _context.Transactions.Remove(_context.Transactions.Find(id));
            _context.SaveChanges();
        }
    }
}