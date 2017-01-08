using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Repository.Entities;

namespace CustomerPayments.Repository.Factories
{
    public class AccountFactory
    {
        public AccountFactory()
        {

        }

        public Data.Account CreateAccount (Account account)
        {
            return new Data.Account()
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber,
                DateCreated = account.DateCreated,
                AccountType = account.AccountType
            };
        }

        public Account CreateAccount(Data.Account account)
        {
            return new Account()
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber,
                DateCreated = account.DateCreated,
                AccountType = account.AccountType
            };
        }
    }
}
