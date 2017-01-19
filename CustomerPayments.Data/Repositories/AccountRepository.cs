using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Data.Repositories.Generic;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Data.Repositories
{
    public class AccountRepository: GenericRepository<Account>
    {
        public AccountRepository(CustomerPaymentsContext context): base(context) {}
    }
}
