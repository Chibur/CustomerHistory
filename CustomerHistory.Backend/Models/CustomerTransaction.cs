using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerHistory.Backend.Models
{
    public class CustomerTransaction
    {
        public int id { get; set; }
        public string accountFrom { get; set; }
        public string accountTo { get; set; }
        public int customerId { get; set; }
        public int accountId { get; set; }
    }
}