using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountFrom_Id { get; set; }
        public int AccountTo_Id { get; set; }
        public int CustomerFrom_Id { get; set; }
        public int CustomerTo_Id { get; set; }
        public DateTime DateSubmitted { get; set; }
        public decimal Amount { get; set; }
    }
}
