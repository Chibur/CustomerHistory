using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class CustomerTransaction
    {
        public int Id { get; set; }
        public int AccountFromId { get; set; }
        public int AccountToId { get; set; }
        public int CustomerFromId { get; set; }
        public int CustomerToId { get; set; }
        public DateTime TransactionSubmitted { get; set; }
        public decimal Amount { get; set; }
    }
}
