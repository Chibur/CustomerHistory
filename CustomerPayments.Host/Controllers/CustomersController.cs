using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Configuration;
using Newtonsoft.Json;
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
        private readonly GenericRepository<Customer> _repo;

        public CustomersController(GenericRepository<Customer> repo)
        {
            _repo = repo;
        }
        // TODO implement exception logging


        //// GET: api/Customers // not necessary
        //[HttpGet]
        //[Route("Customers")]
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        var c = _repo.FindAll();
                  //if (c == null)
                  //  NotFound();
        //        return Ok(customers.Select(c => CustomerMapper.Map(c)));
        //    }
        //    catch
        //    {
        //        return InternalServerError();
        //    }
        //}

        // GET: api/Customers/5
        [HttpGet]
        [Route("Customers/{id}")]
        public IHttpActionResult Get(int? id)
        {
            try
            {
                if (id == null)
                    BadRequest();

                var customer = _repo.FindById((int)id);
                if (customer == null)
                    return NotFound();

                return Ok(CustomerMapper.Map(customer));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        // POST: api/Customers
        [HttpPost]
        [Route("Customers")]
        public IHttpActionResult Post([FromBody]DTO.Customer c)
        {
            try
            {
                if (c == null)
                   return BadRequest();

                var entityC = CustomerMapper.Map(c);
                _repo.Insert(entityC);
                return Created<DTO.Customer>("Customers", c); // maybe Ok() instead?
            }
            catch
            {
                return InternalServerError();
            }
        }

        // PUT: api/Customers/5
        [Route("Customers/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]DTO.Customer c)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest();
                }
                // map
                var entityC = CustomerMapper.Map(c);
                if (_repo.FindById(id) == null)
                    return NotFound();
                                       
                _repo.Update(entityC);
                return Ok(c);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Customers/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<DTO.Customer> cPatchDocument)
        {
            try
            {
                // find 
                if (cPatchDocument == null)
                {
                    return BadRequest();
                }
                var entityC = _repo.FindById(id);
                if (entityC == null)
                {
                    return NotFound();
                }
                //// map
                var c = CustomerMapper.Map(entityC);
                // apply changes to the DTO
                cPatchDocument.ApplyTo(c);
                // map the DTO with applied changes to the entity, & update
                _repo.Update(CustomerMapper.Map(c));
                // map to dto
                return Ok(c);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Customers/5
        [Route("Customers/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                    BadRequest();

                if (_repo.FindById(id.Value) != null)
                    _repo.Delete(id.Value);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
