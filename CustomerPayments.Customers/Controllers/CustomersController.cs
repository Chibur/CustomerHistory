using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Configuration;
using CustomerPayments.DataModel;
using CustomerPayments.DataModel.Repositories;
using Newtonsoft.Json;

namespace CustomerPayments.Host.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomerRepository _repo = new CustomerRepository();

        public Customer Get(int id)
        {
            return _repo.GetCustomerById(id);
        }

        public ICollection<Customer> GetAll()
        {
            return _repo.GetCustomerWithAccounts();
        }

        public void Post([FromBody] object customer)
        {
            var asCustomer = JsonConvert.DeserializeObject<Customer>(customer.ToString());

            _repo.SaveUpdatedCustomer(asCustomer);
        }

        public void Put(int id, [FromBody] Customer Customer)
        {
            _repo.SaveNewCustomer(Customer);
        }

        public void Delete(int id)
        {
            _repo.DeleteCustomer(id);
        }
    }
}
