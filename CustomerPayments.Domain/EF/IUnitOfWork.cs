using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Domain.EF
{
    public interface IUnitOfWork
    {
        IObjectSet<Customer> Customers { get; }
        void Commit();
    }
}
