using CustomerPayments.Data.Mappers;
using CustomerPayments.Data.Repositories;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Domain.Entities;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerPayments.Customers.Controllers
{
    [RoutePrefix("api")]
    public class TransactionsController : ApiController
    {
        private readonly TransactionRepository _repo;

        public TransactionsController(TransactionRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Transactions
        [HttpGet]
        [Route("Transactions")]
        public IHttpActionResult Get()
        {
            try
            {
                var transactions = _repo.FindAll();

                return Ok(transactions.Select(t => TransactionMapper.Map(t)));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Accounts/{accountId}/Transactions")]
        public IHttpActionResult GetByAccount(int accountId)
        {
            try
            {
                var transactions = _repo.FindAll(accountId);

                return Ok(transactions.Select(t => TransactionMapper.Map(t)));
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
                var transaction = _repo.Find(id);
                return Ok(TransactionMapper.Map(transaction));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Transactions/5
        [HttpGet]
        [Route("Accounts/{accountId}/Transactions/{id}")]
        public IHttpActionResult Get(int id, int accountId)
        {
            try
            {
                var transactions = _repo.FindAll(accountId);
                return Ok(TransactionMapper.Map(transactions.ToList().ElementAt(id+1))); // TODO find another way as it would not work with big set of data
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
                if (transaction == null)
                    BadRequest();

                var trns = TransactionMapper.Map(transaction);
                var result = _repo.Add(trns);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newAcc = TransactionMapper.Map(result.Entity);
                    return Created<DTO.Transaction>(Request.RequestUri + "/" + transaction.Id.ToString(), newAcc);
                }
                return BadRequest();

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
                if (transaction == null)
                {
                    return BadRequest();
                }

                // map
                var trns = TransactionMapper.Map(transaction);

                var result = _repo.Update(trns);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedTransaction = TransactionMapper.Map(result.Entity);
                    return Ok(updatedTransaction);
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

        [Route("Transactions/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<DTO.Transaction> transactionPatchDocument)
        {
            try
            {
                // find 
                if (transactionPatchDocument == null)
                {
                    return BadRequest();
                }

                var transaction = _repo.Find(id);
                if (transaction == null)
                {
                    return NotFound();
                }

                //// map
                var trns = TransactionMapper.Map(transaction);

                // apply changes to the DTO
                transactionPatchDocument.ApplyTo(trns);

                // map the DTO with applied changes to the entity, & update
                var result = _repo.Update(TransactionMapper.Map(trns));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedExpense = TransactionMapper.Map(result.Entity);
                    return Ok(updatedExpense);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Transactions/5
        [Route("Transactions/{id}")]
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
