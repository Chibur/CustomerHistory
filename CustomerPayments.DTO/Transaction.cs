using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.DTO
{
    public class TransactionDTO
    {
        public decimal Amount { get; set; }
        public string Discription { get; set; }
        public string BeneficiaryAccount { get; set; }
        public string SenderAccount { get; set; }
    }
}
