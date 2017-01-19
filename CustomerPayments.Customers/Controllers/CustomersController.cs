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
using CustomerPayments.Domain.Entities;
using CustomerPayments.Data.Mappers;
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
        //public IEnumerable<DTO.Customer> Get()
        //{
        //    List<DTO.Customer> cust; 
        //    IEnumerable cs = _repo.All();
        //    foreach(Customer c in cs)
        //    {
        //        cust.Add(CustomerMapper.MapCustomer(c));
        //    }

        //    return new IEnumerable<DTO.Customer> { };
        //}

       // GET: api/Transactions/5
        [HttpGet]
        public DTO.Customer Get(int id)
        {
            return _repo.FindById(id);
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
