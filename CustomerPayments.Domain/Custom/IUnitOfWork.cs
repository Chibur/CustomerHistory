using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Domain.Custom
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }
        void Commit();
    }
}
