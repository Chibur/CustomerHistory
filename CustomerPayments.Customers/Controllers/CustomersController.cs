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
    [RoutePrefix("api")]
    public class CustomersController : ApiController
    {
        private readonly IRepository<Customer> _repo;

        //public CustomersController()
        //{
        //    _repo = new CustomerRepository(new CustomerPaymentsContext());
        //}

        public CustomersController(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        // GET: api/Customers
        [HttpGet]
        [Route("Customers")]
        public IHttpActionResult Get()
        {
            try
            {
                var customers = _repo.FindAll();

                return Ok(customers.Select(c => CustomerMapper.Map(c)));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Customers/5
        [HttpGet]
        [Route("Customers/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var customer = _repo.Find(id);
                return Ok(CustomerMapper.Map(customer));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/Customers
        [HttpPost]
        [Route("Customers")]
        public IHttpActionResult Post([FromBody]DTO.Customer customer)
        {
            try
            {
                _repo.Add(CustomerMapper.Map(customer));
                return Created<DTO.Customer>(Request.RequestUri + "/" + customer.Id.ToString(), customer); // TODO: return record retreaved from db
            }
            catch
            {
                return InternalServerError();
            }
        }

        // PUT: api/Customers/5
        [Route("Customers/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]DTO.Customer customer)
        {
            try
            {
                _repo.Update(CustomerMapper.Map(customer));
                return Ok(customer); // TODO return repo status code
            }
            catch
            {
                return InternalServerError();
            }

        }

        // DELETE: api/Customers/5
        [Route("Customers/{id}")]
        [HttpDelete]
        public IHttpActionResult delete(int id)
        {
            try
            {
                _repo.Remove(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
