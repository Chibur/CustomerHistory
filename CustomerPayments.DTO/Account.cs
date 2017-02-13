using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPayments.Domain.Enums;

namespace CustomerPayments.DTO
{
    public class AccountDTO
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public int? CustomerId { get; set; }
    }
}

