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
using Marvin.JsonPatch;

namespace CustomerPayments.Host.Controllers
{
    [RoutePrefix("api")]
    public class CustomersController : ApiController
    {
        private readonly CustomerRepository _repo;

        public CustomersController(CustomerRepository repo)
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
                if (customer == null)
                   return BadRequest();

                var cst = CustomerMapper.Map(customer);
                var result = _repo.Add(cst);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newAcc = CustomerMapper.Map(result.Entity);
                    return Created<DTO.Customer>(Request.RequestUri + "/" + customer.Id.ToString(), newAcc);
                }
                return BadRequest();

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
                if (customer == null)
                {
                    return BadRequest();
                }

                // map
                var cst = CustomerMapper.Map(customer);

                var result = _repo.Update(cst);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedCustomer = CustomerMapper.Map(result.Entity);
                    return Ok(updatedCustomer);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Customers/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<DTO.Customer> customerPatchDocument)
        {
            try
            {
                // find 
                if (customerPatchDocument == null)
                {
                    return BadRequest();
                }

                var customer = _repo.Find(id);
                if (customer == null)
                {
                    return NotFound();
                }

                //// map
                var cst = CustomerMapper.Map(customer);

                // apply changes to the DTO
                customerPatchDocument.ApplyTo(cst);

                // map the DTO with applied changes to the entity, & update
                var result = _repo.Update(CustomerMapper.Map(cst));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedExpense = CustomerMapper.Map(result.Entity);
                    return Ok(updatedExpense);
                }

                return BadRequest();
            }
            catch (Exception)
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

                var result = _repo.Remove(id);

                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
