using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Configuration;
using Newtonsoft.Json;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Data.Mappers;
using CustomerPayments;
using CustomerPayments.Data.Repository;
using Marvin.JsonPatch;
using AutoMapper;
using CustomerPayments.DTO;
using CustomerPayments.Domain.Interfaces;

namespace CustomerPayments.Host.Controllers
{
    [RoutePrefix("api")]
    public class CustomersController : ApiController
    {
        private readonly IGenericRepository<Customer> _repo;
        private readonly IMapper _mapper;

        public CustomersController(IGenericRepository<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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
              
                var c = _mapper.Map<CustomerDTO>(customer);
                return Ok(c);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        // POST: api/Customers
        [HttpPost]
        [Route("Customers")]
        public IHttpActionResult Post([FromBody]CustomerDTO c)
        {
            try
            {
                // TODO remove as I have filter for that
                if (c == null)
                    return BadRequest();

                var entityC = _mapper.Map<Customer>(c);
                // TODO status code from db
                _repo.Insert(entityC);
                return Created<CustomerDTO>("Customers", c); // maybe Ok() instead?
            }
            catch
            {
                return InternalServerError();
            }
        }

        // PUT: api/Customers/5
        [Route("Customers/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]CustomerDTO c)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest();
                }
                // map
                var entityC = _mapper.Map<Customer>(c);
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
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<CustomerDTO> cPatchDocument)
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
                // map
                var c = _mapper.Map<CustomerDTO>(entityC);
                // apply changes to the DTO
                cPatchDocument.ApplyTo(c);
                // map the DTO with applied changes to the entity, & update
                _repo.Update(_mapper.Map<Customer>(c));
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
