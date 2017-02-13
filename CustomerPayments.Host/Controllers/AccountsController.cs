using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using CustomerPayments;
using CustomerPayments.Data.Mappers;
using CustomerPayments.Data.Repository;
using CustomerPayments.Domain.Entities;
using Marvin.JsonPatch;
using AutoMapper;
using CustomerPayments.DTO;
using CustomerPayments.Domain.Interfaces;

namespace CustomerPayments.Host.Controllers
{
    [RoutePrefix("api")]
    public class AccountsController : ApiController
    {
        private readonly IGenericRepository<Account> _repo;
        private readonly IMapper _mapper;
        public AccountsController (IGenericRepository<Account> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Accounts/{customerId}")]
        public IHttpActionResult Get(int? customerId)
        {
            try
            {
                if (customerId == null)
                    return BadRequest();

                var accs = _repo.FindBy(c=> c.CustomerId == customerId);
                if (accs == null)
                    return NotFound();

                return Ok(accs.Select(a=> _mapper.Map<AccountDTO>(a)));
            }
            catch(Exception e)
            {
               // _logger.Log(e);
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Customers")]
        public IHttpActionResult Post([FromBody]AccountDTO a)
        {
            try
            {
                if (a == null)
                    return BadRequest();

                var entityA = _mapper.Map<Account>(a);
                _repo.Insert(entityA);
                return Created<AccountDTO>("Account", a); // maybe Ok() instead?
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("Accounts/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AccountDTO a)
        {
            try
            {
                if (a == null)
                {
                    return BadRequest();
                }
                // map
                var entityA = _mapper.Map<Account>(a);
                if (_repo.FindById(id) == null)
                    return NotFound();

                _repo.Update(entityA);
                return Ok(a);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Accounts/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<AccountDTO> aPatchDocument)
        {
            try
            {
                // find 
                if (aPatchDocument == null)
                {
                    return BadRequest();
                }
                var entityA = _repo.FindById(id);
                if (entityA == null)
                {
                    return NotFound();
                }
                //// map
                var a = _mapper.Map<AccountDTO>(entityA);
                // apply changes to the DTO
                aPatchDocument.ApplyTo(a);
                // map the DTO with applied changes to the entity, & update
                _repo.Update(_mapper.Map<Account>(a));
                // map to dto
                return Ok(a);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Accounts/{id}")]
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
