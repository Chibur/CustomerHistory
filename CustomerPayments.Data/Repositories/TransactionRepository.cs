using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Data.Repositories
{
    public class TransactionRepository: GenericRepository<Transaction>
    {
        public TransactionRepository(CustomerPaymentsContext context) : base(context) { }
    }
}
