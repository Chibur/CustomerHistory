using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Data.Mappers
{
    class TransactionMapper
    {
        public DTO.Transaction CreateTransaction(Transaction transaction)
        {
            return new DTO.Transaction()
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Discription = transaction.Discription,
                BeneficiaryAccount = transaction.BeneficiaryAccount,
                SenderAccount = transaction.SenderAccount
            };
        }

        public Transaction CreateTransaction(DTO.Transaction transaction)
        {
            return new Transaction()
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Discription = transaction.Discription,
                BeneficiaryAccount = transaction.BeneficiaryAccount,
                SenderAccount = transaction.SenderAccount
            };
        }
    }
}
