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

            _context = new ObjectContext(connectionString);
            _context.ContextOptions.LazyLoadingEnabled = true;
        }

        public IObjectSet<Customer> Customers
        {
            get { return _context.CreateObjectSet<Customer>(); }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        readonly ObjectContext _context;
        const string ConnectionStringName = "CustomerPaymentContext";
    }
}
