using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Data.Repositories
{
    public class CustomerRepository
    {
        private readonly CustomerPaymentsContext _context;
        public CustomerRepository(CustomerPaymentsContext context)
        {
            _context = context;
        }

        //public List<Customer> GetQueryableNinjasWithClan(string query, int page, int pageSize)
        //{
        //    //context.Database.Log = message => Debug.WriteLine(message);
        //    var linqQuery = _context.Customers;
        //    if (!string.IsNullOrEmpty(query))
        //    {
        //        linqQuery = linqQuery.Where(n => n.LastName.Contains(query)).AsQueryable();
        //    }
        //    if (page > 0 && pageSize > 0)
        //    {
        //        linqQuery = linqQuery.OrderBy(n => n.LastName).Skip(page - 1).Take(pageSize);
        //    }

        //    return linqQuery.ToList();
            //}
        //}

    }
}
