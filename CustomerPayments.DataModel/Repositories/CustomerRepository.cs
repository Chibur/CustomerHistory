using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.DataModel.Repositories
{
    public class CustomerRepository
    {
        public ICollection<Customer> GetCustomerWithAccounts()
        {
            using (var context = new CustomerPaymentsContext())
            {
                return context.Customers.AsNoTracking().Include(n => n.Accounts).ToList();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var context = new CustomerPaymentsContext())
            {
                return context.Customers.Find(id);
            }
        }

        public void SaveUpdatedCustomer(Customer customer)
        {
            using (var context = new CustomerPaymentsContext())
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SaveNewCustomer(Customer customer)
        {
            using (var context = new CustomerPaymentsContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var context = new CustomerPaymentsContext())
            {
                var customer = context.Customers.Find(customerId);
                context.Entry(customer).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}