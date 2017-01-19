using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;
using CustomerPayments.Domain.Enums;
using CustomerPayments;

namespace CustomerPayments.Data.Mappers
{
    public static class AccountMapper
    {
        public static DTO.Account CreateAccount(Account account)
        {
            return new DTO.Account()
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber,
                AccountType = account.AccountType
            };
        }

        public static Account CreateAccount(DTO.Account account)
        {
            return new Account()
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber,
                AccountType = account.AccountType
            };
        }
    }
}
