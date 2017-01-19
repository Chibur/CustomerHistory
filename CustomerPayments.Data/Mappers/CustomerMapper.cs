using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Data.Mappers
{
    public static class CustomerMapper
    {
        public static DTO.Customer CreateCustomer(Customer customer)
        {
            return new DTO.Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                Birthdate = customer.Birthdate
            };
        }

        public static Customer CreateCustomer(DTO.Customer customer)
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
