using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Data.Mappers
{
    public static class TransactionMapper
    {
        public static DTO.Transaction Map(Transaction transaction)
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

        public static Transaction Map(DTO.Transaction transaction)
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
