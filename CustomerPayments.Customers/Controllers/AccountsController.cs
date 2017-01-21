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

namespace CustomerPayments.Customers.Controllers
{
    [RoutePrefix("api")]
    public class AccountsController : ApiController
    {
        private readonly IRepository<Account>_repo;
        public AccountsController (IRepository<Account> repo)
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

        // POST: api/Accounts
        [HttpPost]
        [Route("Accounts")]
        public IHttpActionResult Post([FromBody]DTO.Account account)
        {
            try
            {
                _repo.Add(AccountMapper.Map(account));
                return Created<DTO.Account>(Request.RequestUri + "/" + account.Id.ToString(), account); // TODO: return record retreaved from db
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
                _repo.Update(AccountMapper.Map(account));
                return Ok(account); // TODO return repo status code
            }
            catch
            {
               return  InternalServerError();
            }

        }

        // DELETE: api/Accounts/5
        [Route("Accounts/{id}")]
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
