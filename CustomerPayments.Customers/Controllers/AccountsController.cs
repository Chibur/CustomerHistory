using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerPayments;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Data.Mappers;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Data.Repositories;
using Marvin.JsonPatch;

namespace CustomerPayments.Customers.Controllers
{
    [RoutePrefix("api")]
    public class AccountsController : ApiController
    {
        private readonly AccountRepository _repo;
        public AccountsController (AccountRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Accounts
        [HttpGet]
        [Route("Accounts")]
        public IHttpActionResult Get()
        {
            try
            {
                var accounts = _repo.FindAll();

                return Ok(accounts.Select(a => AccountMapper.Map(a)));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Accounts
        [HttpGet]
        [Route("Customers/{customerId}/Accounts")]
        public IHttpActionResult GetByCustomer(int customerId)
        {
            try
            {
                var accounts = _repo.FindAll(customerId);

                return Ok(accounts.Select(a => AccountMapper.Map(a)));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Accounts/5
        [HttpGet]
        [Route("Accounts/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var account = _repo.Find(id);
                return Ok(AccountMapper.Map(account));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("Customers/{customerId}/Accounts/{id}")]
        public IHttpActionResult Get(int id, int customerId)
        {
            try
            {
                var accounts = _repo.FindAll(customerId);
                return Ok(AccountMapper.Map(accounts.ToList().ElementAt(id+1))); // TODO // TODO find another way as it would not work with big set of data
            }
            catch
            {
                return NotFound();
            }
        }


        // POST: api/Accounts
        [HttpPost]
        [Route("Accounts")]
        public IHttpActionResult Post([FromBody]DTO.Account account)
        {
            try
            {
                if (account == null)
                    BadRequest();

                var acc = AccountMapper.Map(account);
                var result = _repo.Add(acc);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newAcc = AccountMapper.Map(result.Entity);
                    return Created<DTO.Account>(Request.RequestUri + "/" + account.Id.ToString(), newAcc);
                }
                return BadRequest();
                
            }
            catch
            {
               return InternalServerError();
            }
        }

        // PUT: api/Accounts/5
        [Route("Accounts/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]DTO.Account account)
        {
            try
            {
                if (account == null)
                {
                    return BadRequest();
                }

                // map
                var acc = AccountMapper.Map(account);

                var result = _repo.Update(acc);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedAccount = AccountMapper.Map(result.Entity);
                    return Ok(updatedAccount);
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

        [Route("Accounts/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<DTO.Account> accountPatchDocument)
        {
            try
            {
                // find 
                if (accountPatchDocument == null)
                {
                    return BadRequest();
                }

                var account = _repo.Find(id);
                if (account == null)
                {
                    return NotFound();
                }

                //// map
                var acc = AccountMapper.Map(account);

                // apply changes to the DTO
                accountPatchDocument.ApplyTo(acc);

                // map the DTO with applied changes to the entity, & update
                var result = _repo.Update(AccountMapper.Map(acc));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedExpense = AccountMapper.Map(result.Entity);
                    return Ok(updatedExpense);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Accounts/5
        [Route("Accounts/{id}")]
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
