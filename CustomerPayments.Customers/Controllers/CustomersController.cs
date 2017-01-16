using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Configuration;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Data.Repository;
using Newtonsoft.Json;

namespace CustomerPayments.Host.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly GenericRepository<Customer> _repo;

        public CustomersController(GenericRepository<Customer> repo)
        {
            _repo = repo;
        }

        // GET: api/Transactions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transactions/5
        public Customer Get(int id)
        {
            return _repo.FindByKey(id);
        }

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
