using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Repository.Entities;

namespace CustomerPayments.Repository.Factories
{
    public class CustomerFactory
    {
        public CustomerFactory()
        {

        }

        public Data.Customer CreateCustomer(Customer customer)
        {
            return new Data.Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                Birthdate = customer.Birthdate
            };
        }

        public Customer CreateCustomer(Data.Customer customer)
        {
            return new Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                Birthdate = customer.Birthdate
            };
        }
    }
}
