using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Domain;
using CustomerPayments.Domain.EF;
using System.Data.Entity;
using CustomerPayments.Data.Custom;

namespace CustomerPayments.Data.EF
{
    class SqlUnitOfWork: IUnitOfWork
    {
        public SqlUnitOfWork()
        {
            var connectionString =
                ConfigurationManager
                    .ConnectionStrings[ConnectionStringName]
                    .ConnectionString;

            _context = new CustomerPaymentsContext(connectionString);
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Customer> Customers
        {
            get { return _context.Set<Customer>(); }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        readonly CustomerPaymentsContext _context;
        const string ConnectionStringName = "CustomerPaymentContext";
    }
}
