using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Repository.Entities;

namespace CustomerPayments.Repository.Factories
{
    public class TransactionFactory
    {
        public TransactionFactory()
        {

        }

        public Data.Transaction CreateTransaction(Transaction transaction)
        {
            return new Data.Transaction()
            {
                Id = transaction.Id,
                AccountFromId = transaction.AccountFromId,
                AccountToId = transaction.AccountToId,
                CustomerFromId = transaction.CustomerFromId,
                CustomerToId = transaction.CustomerToId,
                TransactionSubmitted = transaction.TransactionSubmitted,
                Amount = transaction.Amount
            };
        }

        public Transaction CreateTransaction(Data.Transaction transaction)
        {
            return new Transaction()
            {
                Id = transaction.Id,
                AccountFromId = transaction.AccountFromId,
                AccountToId = transaction.AccountToId,
                CustomerFromId = transaction.CustomerFromId,
                CustomerToId = transaction.CustomerToId,
                TransactionSubmitted = transaction.TransactionSubmitted,
                Amount = transaction.Amount
            };
        }
    }
}
