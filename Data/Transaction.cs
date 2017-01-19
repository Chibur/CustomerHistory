using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.DTO
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Discription { get; set; }
        public string BeneficiaryAccount { get; set; }
        public int? AccountId { get; set; }
    }
}
