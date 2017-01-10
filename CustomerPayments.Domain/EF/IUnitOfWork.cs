using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;
using System.Data.Entity;

namespace CustomerPayments.Domain.EF
{
    public interface IUnitOfWork
    {
        IDbSet<Customer> Customers { get; }
        void Commit();
    }
}
