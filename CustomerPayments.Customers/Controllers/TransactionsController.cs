using CustomerPayments.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerPayments.Customers.Controllers
{
    public class TransactionsController : ApiController
    {
        private readonly TransactionRepository _repo;
        public TransactionsController()
        {
            _repo = new TransactionRepository();
        }
        // GET: api/Transactions
        [HttpGet]
        [Route("Transactions")]
        public IHttpActionResult Get()
        {
            try
            {
                var transactions = _repo.FindAll();

                return Ok(transactions.Select(a => transactions));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Transactions/5
        [HttpGet]
        [Route("Transactions/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var transaction = _repo.FindTransaction(id);
                return Ok(transaction);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/Transactions
        [HttpPost]
        [Route("Transactions")]
        public IHttpActionResult Post([FromBody]DTO.Transaction transaction)
        {
            try
            {
                _repo.Add(transaction);
                return Created<DTO.Transaction>(Request.RequestUri + "/" + transaction.Id.ToString(), transaction); // TODO: return record retreaved from db
            }
            catch
            {
               return InternalServerError();
            }
        }

        // PUT: api/Transactions/5
        [Route("Transactions/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]DTO.Transaction transaction)
        {
            try
            {
                _repo.Update(transaction);
                return Ok(transaction); // TODO return repo status code
            }
            catch
            {
               return  InternalServerError();
            }

        }

        // DELETE: api/Transactions/5
        [Route("Transactions/{id}")]
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
