using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Data.Mappers;
using CustomerPayments;

namespace CustomerPayments.Data.Repositories
{
    public class CustomerRepository
    {
        private readonly CustomerPaymentsContext _context;

        public CustomerRepository(CustomerPaymentsContext context)
        {
            _context = context;
        }

        public DTO.Customer FindById(int id)
        {
            var customer = _context.Customers.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return CustomerMapper.MapCustomer(customer);
        }

        public IEnumerable<DTO.Customer> FindAll()
        {
            return _context.Customers.AsNoTracking()
                .Select(c => CustomerMapper.MapCustomer(c));
        }
        public void Add(DTO.Customer customer)
        {
            _context.Customers.Add(
                CustomerMapper.MapCustomer(customer));
            _context.SaveChanges();
        }

        public void Update(DTO.Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveCustomer(int id)
        {
            _context.Customers.Remove(_context.Customers.Find(id));
            _context.SaveChanges();
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
