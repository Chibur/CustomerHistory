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
    public class CustomerRepository
    {
        private readonly CustomerPaymentsContext _context;

        public CustomerRepository(CustomerPaymentsContext context)
        {
            _context = context;
        }

        public Customer Find(int id)
        {
            var customer = _context.Customers.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return customer;
        }

        public IEnumerable<Customer> FindAll()
        {
            return _context.Customers.AsNoTracking();
        }

        public RepositoryActionResult<Customer> Add(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Customer>(customer, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Customer>(customer, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Customer>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<Customer> Update(Customer customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Modified;
                var existingCustomer = _context.Customers.FirstOrDefault(a => a.Id == customer.Id);

                if (existingCustomer == null)
                {
                    return new RepositoryActionResult<Customer>(customer, RepositoryActionStatus.NotFound);
                }
                _context.Entry(customer).State = EntityState.Detached;
                _context.Customers.Attach(customer);
                _context.Entry(customer).State = EntityState.Modified;
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Customer>(customer, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Customer>(customer, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Customer>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<Customer> Remove(int id)
        {
            try
            {
                var customer = _context.Customers.Where(e => e.Id == id).FirstOrDefault();
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    return new RepositoryActionResult<Customer>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<Customer>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Customer>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
