using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerPayments;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Customers.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly GenericRepository<Account> _repo;
        public AccountsController()
        {
            _repo = new GenericRepository<Account>(new CustomerPaymentsContext());
        }
        // GET: api/Accounts
        public IEnumerable<Account> Get()
        {
            return _repo.All();
        }

        // GET: api/Accounts/5
        public Account Get(int? id)
        {
            return _repo.FindByKey(id.Value);
        }
        [HttpGet]
        [Route("GetAllIncluded")]
        public IEnumerable<Account>GetAllIncluded()
        {
            return _repo.AllInclude(e => e.Id);
        }

        // POST: api/Accounts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Accounts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Accounts/5
        public void Delete(int id)
        {
        }
    }
}
