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

namespace CustomerPayments.Customers.Controllers
{
    [RoutePrefix("api")]
    public class AccountsController : ApiController
    {
        private readonly GenericRepository<Account> _repo;
        public AccountsController()
        {
            _repo = new GenericRepository<Account>(new CustomerPaymentsContext());
        }
        // GET: api/Accounts
        public IHttpActionResult Get()
        {
            try
            {
                var accounts = _repo.All();

                return Ok(accounts.Select(a => AccountMapper.MapAccount(a)));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Accounts/5
        public IHttpActionResult Get(int? id)
        {
            try
            {
                var account = _repo.FindByKey(id.Value);
                return Ok(AccountMapper.MapAccount(account));
            }
            catch
            {
                return NotFound();
            }
        }
        //[HttpGet]
        //[Route("GetAllIncluded")]
        //public IEnumerable<Account>GetAllIncluded()
        //{
        //    return _repo.AllInclude(e => e.Id);
        //}

        // POST: api/Accounts
        [HttpPost]
        [Route("Accounts")]
        public IHttpActionResult Post([FromBody]DTO.Account account)
        {
            try
            {
                var acc = AccountMapper.MapAccount(account);

            }
            catch
            {

            }
        }

        // PUT: api/Accounts/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Accounts/5
        public IHttpActionResult Delete(int id)
        {
        }
    }
}
