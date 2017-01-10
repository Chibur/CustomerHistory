﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Custom;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using CustomerPayments.Domain.Entities;
using System.Collections.Specialized;
using CustomerPayments.Domain;

namespace CustomerPayments.Data.Custom
{
    public class SqlUnitOfWork: IUnitOfWork
    {
        SqlRepository<Customer> _customers = null;
        readonly ObjectContext _context;
        const string ConnectionStringName = "EmployeeDataModelContainer";

        public SqlUnitOfWork()
        {
            var connectionString =
                ConfigurationManager
                    .ConnectionStrings[ConnectionStringName]
                    .ConnectionString;

            _context = new ObjectContext(connectionString);
            _context.ContextOptions.LazyLoadingEnabled = true;
        }

        private IRepository<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new SqlRepository<Customer>(_context);
                }
                return _customers;
            }
        }

        IRepository<Customer> IUnitOfWork.Customers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
