using CustomerPayments;
using CustomerPayments.Data.Mappers;
using CustomerPayments.Domain.Entities;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using CustomerPayments.Data.Repository;
using AutoMapper;
using CustomerPayments.DTO;
using CustomerPayments.Domain.Interfaces;

namespace CustomerPayments.Host.Controllers
{
    [RoutePrefix("api")]
    public class TransactionsController : ApiController
    {
        private readonly IGenericRepository<Transaction> _repo;
        private readonly IMapper _mapper;

        public TransactionsController(IGenericRepository<Transaction> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Transactions/{accountId}")]
        public IHttpActionResult Get(int? accountId)
        {
            try
            {
                if (accountId == null)
                    BadRequest();

                var ts = _repo.FindBy(t => t.AccountId == accountId);
                if (ts == null)
                    return NotFound();

                return Ok(ts.Select(t => _mapper.Map<TransactionDTO>(t)));
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Transactions")]
        public IHttpActionResult Post([FromBody]TransactionDTO t)
        {
            try
            {
                if (t == null)
                    return BadRequest();

                var entityT = _mapper.Map<Transaction>(t);
                _repo.Insert(entityT);
                return Created<TransactionDTO>("Transactions", t); // maybe Ok() instead?
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("Transactions/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]TransactionDTO t)
        {
            try
            {
                if (t == null)
                {
                    return BadRequest();
                }
                // map
                var entityT = _mapper.Map<Transaction>(t);
                if (_repo.FindById(id) == null)
                    return NotFound();

                _repo.Update(entityT);
                return Ok(t);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Transactions/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<TransactionDTO> tPatchDocument)
        {
            try
            {
                if (tPatchDocument == null)
                {
                    return BadRequest();
                }
                var entityT = _repo.FindById(id);
                if (entityT == null)
                {
                    return NotFound();
                }
                //// map
                var t = _mapper.Map<TransactionDTO>(entityT);
                // apply changes to the DTO
                tPatchDocument.ApplyTo(t);
                // map the DTO with applied changes to the entity, & update
                _repo.Update(_mapper.Map<Transaction>(t));
                // map to dto
                return Ok(t);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("Transactions/{id}")]
        [HttpDelete]
        public IHttpActionResult delete(int? id)
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
