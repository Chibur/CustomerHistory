using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Configuration;
using Newtonsoft.Json;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Data.Repositories;
using CustomerPayments.Domain;
using CustomerPayments;

namespace CustomerPayments.Host.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomerRepository _repo;

        public CustomersController()
        {
            _repo = new CustomerRepository(new CustomerPaymentsContext());
        }

        public CustomersController(CustomerRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Transactions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transactions/5
        //public Customer Get(int id)
        //{
        //    return _repo.FindByKey(id);
        //}

        // POST: api/Transactions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Transactions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transactions/5
        public void Delete(int id)
        {
        }
    }
}
