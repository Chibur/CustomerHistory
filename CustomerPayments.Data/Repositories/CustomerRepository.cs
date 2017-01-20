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
    public class CustomerRepository
    {
        private readonly CustomerPaymentsContext _context;

        public CustomerRepository(CustomerPaymentsContext context)
        {
            _context = context;
        }

        public DTO.Customer FindCustomer(int id)
        {
            var customer = _context.Customers.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return CustomerMapper.MapCustomer(customer);
        }

        public IEnumerable<DTO.Customer> FindAll()
        {
            return _context.Customers.AsNoTracking()
                .Select(c => CustomerMapper.MapCustomer(c));
        }

        public void Add(DTO.Customer customer)
        {
            _context.Customers.Add(
                CustomerMapper.MapCustomer(customer));
            _context.SaveChanges();
        }

        public void Update(DTO.Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Customers.Remove(_context.Customers.Find(id));
            _context.SaveChanges();
        }
    }
}
